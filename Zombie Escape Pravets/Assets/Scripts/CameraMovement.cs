using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform target;
	Vector3 offset;

	void Start () {
		offset = transform.position - target.position;
	}

	void FixedUpdate() {
		transform.rotation = target.rotation;
		transform.position = target.transform.position + (target.transform.forward * offset.magnitude);
	}

}
