using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1f;
	
	private float xmin;
	private float xmax;
	
//	private Rigidbody2D body;
	
	// Use this for initialization
	void Start () {
//		body = GetComponent<Rigidbody2D>();
		
//		// Distance between the camera and the player object
//		float distance = transform.position.z - Camera.main.transform.position.z;
//		
//		// X, Y values are relative to the screen (0-1).
//		Vector3 leftmostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
//		Vector3 rightmostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
//	
//		// Calculate xmin and xmax from the camera
//		xmin = leftmostPosition.x + padding;
//		xmax = rightmostPosition.x - padding;
	}
	
	// Update is called once before rendering per frame
	void Update () {
		BasicMovement();
	}
	
	void BasicMovement() {
	
		// Left Arrow
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		// Right Arrow
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		// Clamp position of body to playspace
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
	
//	// Called just before performing physics calculations
//	void FixedUpdate() {
//		MoveStarship();
//	}
//	
//	void MoveStarship() {
//	
//		// Grab input from keyboard
//		float moveHorizontal = Input.GetAxis("Horizontal");
//		float moveVertical = Input.GetAxis("Vertical");
//		
//		// Determine direction of force
//		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
//		body.AddForce(movement * speed);
//		
//	}
}
