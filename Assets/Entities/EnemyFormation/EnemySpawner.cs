using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	
	// Use this for initialization
	void Start () {
		
		// For every child in this transform...
		foreach (Transform child in transform) {
			
			// Create an enemy at the origin.
			GameObject enemy = Instantiate(enemyPrefab, new Vector3(child.position.x, child.position.y, child.position.z), Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
