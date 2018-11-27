using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour {

	public int mineDamage = 35;
	public GameObject impactEffect;

	//public float failurePercentage = 0.3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider col){
		CarHealth ch= col.GetComponentInParent<CarHealth> ();
		if (ch != null) {
			ch.DoDamage (mineDamage);
			if (impactEffect != null) {
				//TODO: Show effect on car (Cause its hard to see it at full speed)
				var effect = (GameObject)Instantiate (impactEffect, gameObject.transform.position, gameObject.transform.rotation);
				Destroy (effect, 3.0f);
			}
			Destroy(gameObject);
			Rigidbody body =  col.GetComponentInParent<Rigidbody> ();
			if (body != null) {
				body.AddForce (new Vector3(0.8f,5.0f,0.8f), ForceMode.VelocityChange);
			}
		}
	}
}
