using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float Speed = 6f;
	public float MouseSensitivity = 5f;
	public float JumpHeight = 2f;

	private Vector3 _inputs = Vector3.zero;
	private float _yaw = 0.0f;
	private bool _isGrounded;
	private Rigidbody _body;

	void Start() {
		_body = GetComponent<Rigidbody>();
	}

	void Update () {

		// Movement
		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis("Horizontal");
		_inputs.z = Input.GetAxis("Vertical");
		_inputs = transform.worldToLocalMatrix.inverse * _inputs;
		if (_inputs != Vector3.zero) {
			transform.forward = _inputs;
		}

		// Mouse control
		_yaw += MouseSensitivity * Input.GetAxis("Mouse X");
		transform.eulerAngles = new Vector3(0, _yaw, 0);

		// Jump
		if (Input.GetButtonDown("Jump") && _isGrounded) {
			_body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		}
	}

	void FixedUpdate () {
		_body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
	}

	void OnCollisionEnter(Collision theCollision ) {
		if(theCollision.gameObject.name == "Plane") {
			_isGrounded = true;
		}
	}

	void OnCollisionExit(Collision theCollision) {
		if(theCollision.gameObject.name == "Plane") {
			_isGrounded = false;
		}
	}
}
