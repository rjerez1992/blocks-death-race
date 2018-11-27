using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour {


	public AudioSource target;
	public float timeInSeconds;

	private float startFadeTime;
	private bool isFading;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isFading) {
			float elapsedTime = Time.time - startFadeTime;
			target.volume = (timeInSeconds - elapsedTime) / timeInSeconds;
		}
	}

	public void Fade(){
		this.isFading = true;
		this.startFadeTime = Time.time;
	}
}
