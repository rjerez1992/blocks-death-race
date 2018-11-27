using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInFadeOutMain : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnFadeIn(){		
		//
	}



	public void OnFadeOut(){

		SceneManager.LoadScene ("LevelLoader");

	}

}
