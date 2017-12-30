using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;

//	private Rigidbody2D body;
	
	// Use this for initialization
	void Start () {
//		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once before rendering per frame
	void Update () {
		BasicMovement();
	}
	
	void BasicMovement() {
	
		// Left Arrow
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
		}
		
		// Right Arrow
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		}
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
