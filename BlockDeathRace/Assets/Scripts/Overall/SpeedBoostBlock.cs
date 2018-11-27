using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostBlock : MonoBehaviour {

	public int impulseForce = 1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		//print ("Collided with " + col.gameObject.name);
	}

	void OnTriggerEnter(Collider col){
		//print ("Collided with " + col.gameObject.name);
		Rigidbody body = col.gameObject.GetComponentInParent<Rigidbody> ();
		body.AddForce(body.velocity.normalized * impulseForce, ForceMode.Acceleration);
	}


}
