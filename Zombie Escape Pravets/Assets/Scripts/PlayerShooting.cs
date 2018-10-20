using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	public GameObject bullet;
	///public Camera cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			///Camera cam = Camera.main;
			Instantiate(bullet, transform.position, transform.rotation);
			}
	}
}
