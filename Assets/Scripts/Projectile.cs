﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float damage = 100f;
	
	public float GetDamage() {
		return damage;
	} 
	
	public void Destroy() {
	
		// Destroy this object
		Destroy(gameObject);
	}
}
