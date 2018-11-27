using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public GameObject respawnObject;
	public int respawnTimeRate = 10;
	public GameObject respawnEffect;
	public Transform respawnEffectPosition;

	private float respawnClock;
	private bool working = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (working) {
			if (Time.time - respawnClock > respawnTimeRate) {
				respawnObject.SetActive (true);
				working = false;
				if (respawnEffect != null) {
					var animation = (GameObject)Instantiate (respawnEffect, respawnEffectPosition.position, respawnEffectPosition.rotation);
					Destroy (animation, 2.0f);
				}
			}
		}
	}

	public void StartRespawnTimer(){
		respawnClock = Time.time;
		working = true;
	}
}
