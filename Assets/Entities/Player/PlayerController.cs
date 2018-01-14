using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject playerLaser;
	public float projectileSpeed;
	public float firingRate = 0.2f;

	public float speed = 15.0f;
	public float padding = 1f;
	
	private float xmin;
	private float xmax;
	
	// Use this for initialization
	void Start () {
		
		// Distance between the camera and the player object
		float distance = transform.position.z - Camera.main.transform.position.z;
		
		// X, Y values are relative to the screen (0-1).
		Vector3 leftmostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
	
		// Calculate xmin and xmax from the camera, instead of preset values.
		xmin = leftmostPosition.x + padding;
		xmax = rightmostPosition.x - padding;
	}
	
	// Update is called once before rendering per frame
	void Update () {
		
		// Left Arrow
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		// Right Arrow
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		// Space Down
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.00001f, firingRate);
		}
		
		// Space Up
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		
		// Clamp position of player body to playspace
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
	
	// Fire a beam
	void Fire() {
		GameObject beam = Instantiate(playerLaser, new Vector3(this.transform.position.x, playerLaser.transform.position.y, this.transform.position.z), Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
	}
}
