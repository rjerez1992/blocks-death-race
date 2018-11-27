using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColiision : MonoBehaviour {

	public int damage = 10;
	public GameObject impactEffect;
	public Transform impactPosition;
	public bool destroyOnImpact = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		CarHealth ch= col.GetComponentInParent<CarHealth> ();
		if (ch != null) {
			//Debug.Log ("DID DAMAGE"+damage);
			ch.DoDamage (damage);
			if (impactEffect != null) {
				var effect = (GameObject)Instantiate (impactEffect, impactPosition.position, impactPosition.rotation);
				Destroy (effect, 2.0f);
			}
			if (destroyOnImpact) {
				Destroy(gameObject);
			}

		}
	}
}
