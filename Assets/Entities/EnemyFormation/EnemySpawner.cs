using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	
	public float formationWidth = 10f;
	public float formationHeight = 5f;
	
	public int speed = 1;
	
	private bool movingRight = true;
	
	private float xmin;
	private float xmax;
	
	// Use this for initialization
	void Start () {
		
		// Get edges of screen
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
		xmin = leftEdge.x;
		xmax = rightEdge.x;
		
		
		// For every child in this transform...
		foreach (Transform child in this.transform) {
			
			// Create an enemy at the origin.
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos() {
	
		// Draw cube around formation
		Gizmos.DrawWireCube(transform.position, new Vector3(formationWidth, formationHeight));
	}
	
	// Update is called once per frame
	void Update () {
	
		// Move enemy formation.
		if (movingRight) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		// Switch direction if at edge
		float rightEdgeOfFormation = this.transform.position.x + (0.6f * formationWidth);
		float leftEdgeOfFormation = this.transform.position.x - (0.6f * formationWidth);
		if (leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax) {
			movingRight = !movingRight;
		}
	}
}
