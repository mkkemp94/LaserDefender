using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150;
	
	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		missile.Hit();
		if (missile) {
			health -= missile.GetDamage();
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
