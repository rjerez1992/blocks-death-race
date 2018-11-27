using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public int checkPointNumber = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		
		GameObject ob = GameObject.Find ("SceneControllers");
		RaceController rc = ob.GetComponent<RaceController> ();
		if (rc != null) {
			rc.checkPoint (this.checkPointNumber, col.transform.root.name);
			//Debug.Log ("Check point for " + col.transform.root.name);
		}
	}
}
