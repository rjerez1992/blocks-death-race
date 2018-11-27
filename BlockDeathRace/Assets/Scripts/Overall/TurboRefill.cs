using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboRefill : MonoBehaviour {

	public int refillAmount = 1000;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		print ("Turbo refilled for" + col.gameObject.name);
		TurboBoost turbo = col.gameObject.GetComponentInParent<TurboBoost> ();
		if (turbo != null) {
			turbo.Refill(refillAmount);
		}
	}
}
