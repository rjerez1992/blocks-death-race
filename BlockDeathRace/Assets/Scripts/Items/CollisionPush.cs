using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPush : MonoBehaviour {
	void OnTriggerEnter(Collider col){
		CarHealth ch = col.GetComponentInParent<CarHealth> ();
		if (ch != null) {
			Rigidbody rb = col.GetComponentInParent<Rigidbody> ();
			rb.AddForce (gameObject.transform.forward * -50, ForceMode.VelocityChange);
		}
	}
}
