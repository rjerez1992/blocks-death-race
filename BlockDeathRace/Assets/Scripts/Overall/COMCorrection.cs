using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMCorrection : MonoBehaviour {

	public Rigidbody body;
	public GameObject com;

	// Use this for initialization
	void Start () {
		body.centerOfMass = com.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
