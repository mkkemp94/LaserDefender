using UnityEngine;
using System.Collections;

/*
	This script is attached to each enemy.
*/
public class EnemyBehavior : MonoBehaviour {

	public float health = 150;
	public GameObject projectile;
	public float projectileSpeed = 10;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	private ScoreKeeper scorekeeper;
	
	public AudioClip fireSound;
	public AudioClip destroySound;
	
	void Start() {
		scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update() {
		
		// Fire randomly, based off frame rate
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire();
		}
	}
	
	// Shoot a missile
	void Fire() {
		Vector3 startPosition = transform.position + new Vector3(0, -1f, 0);
		GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	// When something enters this trigger space
	void OnTriggerEnter2D(Collider2D collider) {
	
		// Get the projectile object while is colliding with this enemy
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		
		// If the projectile exists
		if (missile) {
		
			// Destroy the missile
			missile.Destroy();
			
			// Reduce the health of this enemy by the missile's damage
			health -= missile.GetDamage();
			if (health <= 0) {
				Die();
			}
		}
	}
	
	void Die() {
		AudioSource.PlayClipAtPoint(destroySound, transform.position);
		Destroy(gameObject);
		scorekeeper.Score(scoreValue);
	}
	
	
}
