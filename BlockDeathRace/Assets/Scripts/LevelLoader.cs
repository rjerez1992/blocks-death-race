using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public Text progress;
	public Animator anim;
	private AsyncOperation operation;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnFadeIn(){		

		StartCoroutine (LoadAsync (PlayerPrefs.GetString("SceneToLoad")));
		//StartCoroutine (LoadAsync ("SwiftnessTrack"));
	}

	IEnumerator LoadAsync(string sceneName){
		operation = SceneManager.LoadSceneAsync (sceneName);
		operation.allowSceneActivation = false;
		while (!operation.isDone) {
			float p = Mathf.Clamp01(operation.progress/0.9f);
			progress.text = "Loading\n"+((int)(p*100)) +"%";
			if (p >= 1) {
				//operation.allowSceneActivation = true;

				anim.SetTrigger ("FadeOut");
			}

			yield return null;
		}

	}

	public void OnFadeOut(){
		//Debug.Log ("DONE");
		operation.allowSceneActivation = true;

	}


}
