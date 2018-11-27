using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	public int gravityMultiplier = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddForce(Physics.gravity * rb.mass * gravityMultiplier);
	}
}
