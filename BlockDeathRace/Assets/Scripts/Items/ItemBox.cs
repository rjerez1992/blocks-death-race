using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {

	public GameObject usageAnimation;
	public Transform animationPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		WeaponManager wm = col.GetComponentInParent<WeaponManager> ();
		if (wm != null) {
			wm.NewRandomWeapon ();
			//print ("Collided with " + col.name);


			var animation = (GameObject)Instantiate (usageAnimation, animationPoint.position, animationPoint.rotation);
			Destroy (animation, 1.0f);

			Respawn rs =  gameObject.GetComponentInParent<Respawn> ();
			if (rs != null) {
				rs.StartRespawnTimer ();
			}

			gameObject.SetActive (false);
		}

		//TODO: StartSpawn timer.



	}
}
