using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarRacer : MonoBehaviour {

	public Text lapCount;
	public Text position;
	public Text centerText;
	public Text maxLaps;
	public CarController controller;

	// Use this for initialization
	void Start () {
		GameObject ob = GameObject.Find ("SceneControllers");
		RaceController rc = ob.GetComponent<RaceController> ();
		if (rc != null) {
			rc.subscribePlayer (gameObject.name, lapCount, position, centerText, maxLaps,controller);
			//Debug.Log ("Suscribed player " + gameObject.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
