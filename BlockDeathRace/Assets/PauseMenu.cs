using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;
	public Button resumeButton;
	public Animator fadeAnimation;
	public GameObject finishMenu;
	public AudioSource raceMusic;

	public Button playAgainButton;

	private bool isOpen = false;

	private bool isFinishRaceOpen = false;

	public AudioMixerFader amf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("StartJ1")) {
			if (!isOpen) {
				OpenPauseMenu ();
			} else {
				ClosePauseMenu ();
			}
		}
	}

	void OpenPauseMenu(){
		if (isFinishRaceOpen) {
			return;
		}
		amf.muteMaster ();
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
		/*GameObject myEventSystem = GameObject.Find("EventSystem");
		myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(resumeButton);*/
		resumeButton.Select ();
		resumeButton.OnSelect (null);
		//UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (resumeButton.gameObject);
		isOpen = true;
	}


	public void ClosePauseMenu(){
		amf.unmuteMaster ();
		isOpen = false;
		pauseMenu.SetActive (false);
		Time.timeScale = 1;

	}

	//FADE OUT BACKGROUND MUSIC!!!!

	public void RestartRace(){
		ClosePauseMenu ();
		CloseRaceFinishMenu ();
		PlayerPrefs.SetString ("SceneToLoad", "SwiftnessTrack");	
		fadeAnimation.SetTrigger ("FadeOut");

		amf.fadeOut (1.5f);
	}

	public void ExitRace(){
		ClosePauseMenu ();
		CloseRaceFinishMenu ();
		PlayerPrefs.SetString ("SceneToLoad", "Menu");
		fadeAnimation.SetTrigger ("FadeOut");
		amf.fadeOut (1.5f);
	}




	////////////////// RACE FINISHED MENU
	public void RaceFinishMenu(){
		raceMusic.Stop ();
		Time.timeScale = 0;
		amf.muteEffects ();
		finishMenu.SetActive (true);

		/*GameObject myEventSystem = GameObject.Find("EventSystem");
		myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(playAgainButton);*/
		playAgainButton.Select ();
		playAgainButton.OnSelect (null);


		isFinishRaceOpen = true;
	}

	public void CloseRaceFinishMenu(){
		isFinishRaceOpen = false;
		amf.unmuteEffects ();
		finishMenu.SetActive (false);
		Time.timeScale = 1;
	}


}
