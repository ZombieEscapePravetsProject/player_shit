using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody playerRigidbody;
	public float speed = 6f;

	private Vector3 movement;
	private float yaw = 0.0f;
	private bool isGrounded;

	void Update() {
		yaw += 5 * Input.GetAxis("Mouse X");

		transform.eulerAngles = new Vector3(0, yaw, 0.0f);
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);

		if (Input.GetAxisRaw ("Jump") == 1 && isGrounded) {
			Jump();
		}

	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		movement = transform.worldToLocalMatrix.inverse * movement;
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Jump () {
		playerRigidbody.AddForce(new Vector3(0, 300, 0));
	}

	void OnCollisionEnter(Collision theCollision ) {
		if(theCollision.gameObject.name == "Plane")
		{
			isGrounded = true;
		}
	}

	//consider when character is jumping .. it will exit collision.
	void OnCollisionExit(Collision theCollision) {
		if(theCollision.gameObject.name == "Plane")
		{
			isGrounded = false;
		}
	}
}
