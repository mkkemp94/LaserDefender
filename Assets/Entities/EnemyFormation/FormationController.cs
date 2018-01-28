using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {

	public GameObject enemyPrefab;
	
	public float formationWidth = 10f;
	public float formationHeight = 5f;
	public float speed = 1;
	public float spawnDelay;
	
	
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
		
		// Populate positions with enemies
		SpawnUntilFull();
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
		if (leftEdgeOfFormation < xmin) { 
			movingRight = true;
		}
		else if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		}
		
		if (AllEnemiesDead()) {
			Debug.Log("All enemies dead.");
			SpawnUntilFull();
		}
	}
	
	void SpawnUntilFull() {
	
		Transform parentPosition = NextFreePosition();
		if (null != parentPosition) {
		
			// Create new enemy at the origin
			GameObject newEnemy = Instantiate(enemyPrefab, parentPosition.position, Quaternion.identity) as GameObject;
			newEnemy.transform.parent = parentPosition;
			
			Invoke("SpawnUntilFull", spawnDelay);
		} 
	}
	
	// Get the next free position
	Transform NextFreePosition() {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}
	
	// Check if all enemies are dead
	bool AllEnemiesDead() {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
