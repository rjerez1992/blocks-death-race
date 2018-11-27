using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallIncreasing : MonoBehaviour {

	public float gravityMultiplier = 1.0f;
	public Transform positionTracker;
	public Rigidbody body;
	public float heightThreshold = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (positionTracker.position.y > heightThreshold) {
			Debug.Log ("TAMO");
			body.AddForce (Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
		}*/
	}

	void FixedUpdate(){
			if (positionTracker.position.y > heightThreshold) {
			//Debug.Log ("TAMO");
			body.AddForce (Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
		}
	}
}
