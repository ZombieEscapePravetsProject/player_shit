using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform target;

	private Vector3 offset;
	private float _pitch = 0;

	void Start () {
		offset = transform.position - target.position;
	}

	void Update() {
		Cursor.lockState = CursorLockMode.Locked;
		_pitch += 5 * Input.GetAxis("Mouse Y");
		if (_pitch < -45) {
			_pitch = -45;
		}
		if (_pitch > 45) {
			_pitch = 45;
		}

		Vector3 temp = transform.eulerAngles;
		temp.x = -_pitch;
		transform.eulerAngles = temp;
	}
	void FixedUpdate() {
		transform.rotation = target.rotation;
		transform.position = target.transform.position + (target.transform.forward * offset.magnitude);
	}

}
