using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundSpeed : MonoBehaviour {

	public AudioSource asource;
	public Rigidbody body;

	// Use this for initialization
	void Start () {		
		
	}

	// Update is called once per frame
	void Update () {
		Vector2 vc = new Vector2 (body.velocity.x, body.velocity.z);
		asource.pitch = 0.3f+((vc.magnitude)/120) * 0.8f;
		asource.volume = 0.4f+((vc.magnitude)/120) * 0.2f;
	}
}
