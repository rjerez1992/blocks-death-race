using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerFader : MonoBehaviour {

	public AudioMixer masterMixer;

	private bool isFadingIn;

	private bool isFadingOut;

	private float fadeTime;
	private float startFadeTime;
	private float currentValue;


	private float unmuteEffectsValue;

	// Use this for initialization
	void Start () {
		masterMixer.GetFloat ("EffectsVol", out unmuteEffectsValue);
		masterMixer.SetFloat ("MasterVol", -20f);
		this.fadeIn (1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (isFadingOut) {
			masterMixer.SetFloat ("MasterVol", ((startFadeTime-Time.time) / fadeTime) * 20f);		
			masterMixer.GetFloat ("MasterVol", out currentValue);
			if (currentValue <= -20f) {
				isFadingOut = false;
			}
		} 
		else if (isFadingIn) {
			masterMixer.SetFloat ("MasterVol", (-20f + ((Time.time - startFadeTime) / fadeTime) * 20f));
			masterMixer.GetFloat ("MasterVol", out currentValue);
			//Debug.Log(currentValue);
			if (currentValue >= 0f) {
				//Debug.Log ("NO lLONGER FADING IN");
				isFadingIn = false;
			}
		}
	}

	public void muteMaster(){
		masterMixer.SetFloat ("MasterVol", -80f);
	}

	public void  unmuteMaster(){
		masterMixer.SetFloat ("MasterVol", 0f);	
	}	

	public void fadeIn(float timeInSeconds){
		this.fadeTime = timeInSeconds;
		this.isFadingIn = true;
		this.startFadeTime = Time.time;
	}

	public void fadeOut(float timeInSeconds){
		this.fadeTime = timeInSeconds;
		this.isFadingOut = true;
		this.startFadeTime = Time.time;
	}


	public void muteEffects(){
		masterMixer.GetFloat ("EffectsVol", out unmuteEffectsValue);
		masterMixer.SetFloat ("EffectsVol", -20f);
	}

	public void unmuteEffects(){
		masterMixer.SetFloat ("EffectsVol", unmuteEffectsValue);
	}
}
