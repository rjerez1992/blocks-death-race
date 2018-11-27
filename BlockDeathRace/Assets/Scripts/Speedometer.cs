using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Speedometer : MonoBehaviour {
	
	public Text speedTxt;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 vc = new Vector2 (body.velocity.x, body.velocity.z);
		speedTxt.text = ((int)vc.magnitude)+"";
	}
}
