using UnityEngine;
using System.Collections;

/*
	This script is attached to each enemy.
*/
public class EnemyBehavior : MonoBehaviour {

	public float health = 150;
	public GameObject enemyMissile;
	public float enemyMissileSpeed;
	float maxCounter = Random.value * 300;
	int randomCounter = 0;
	
	// When something enters this trigger space
	void OnTriggerEnter2D(Collider2D collider) {
	
		// Get the projectile object while is colliding with this enemy
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		
		// Destroy the missile
		missile.Destroy();
		
		// If the projectile exists
		if (missile) {
		
			// Reduce the health of this enemy by the missile's damage
			health -= missile.GetDamage();
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}
	
	void Update() {
	
		// Fire randomly
		randomCounter++;
		if (randomCounter >= maxCounter) {
			Fire();
			randomCounter = 0;
			maxCounter = Random.value * 500;
		}
	}
	
	// Shoot a missile
	void Fire() {
		GameObject missile = Instantiate(enemyMissile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector3(0, enemyMissileSpeed, 0);
	}
}
