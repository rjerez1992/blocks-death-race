using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {

	public AudioSource change;
	public AudioSource accept;

	public GameObject mainMenu;
	public GameObject modeSelection;
	public GameObject playerSelection;

	public Button mainMenuFirstItem;
	public Button modeSelectionFirstItem;
	public Button playerSelectionFirstItem;

	public Text gameModeText;
	private string mode;

	public Animator anim;


	public Button playersButton3;
	public Button playersButton4;

	public AudioFader afader;

	// Use this for initialization
	void Start () {
		gameModeText.text = "Undefined";
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown ("FireJ1") || Input.GetMouseButtonDown(0)) {
			accept.Play ();
		}
		if (Input.GetButtonDown ("AccelerateJ1") || Input.GetButtonDown ("BrakeJ1")) {
			change.Play ();
		}*/
		CalculateMaxPlayersQuantity ();
	}

	/** Main menu **/ 
	public void PlayLocal(){
		accept.Play ();
		mainMenu.SetActive (false);
		modeSelection.SetActive (true);
		modeSelectionFirstItem.Select ();
		modeSelectionFirstItem.OnSelect (null);
	}

	public void ExitGame(){
		accept.Play ();
		//Debug.Log ("Closing application");
		Application.Quit ();
	}

	/** Play local menu ***/

	public void PlayLocalGoBack(){
		accept.Play ();
		modeSelection.SetActive (false);
		mainMenu.SetActive (true);
		mainMenuFirstItem.Select ();
		mainMenuFirstItem.OnSelect (null);

	}

	public void SelectMode(string mode){
		accept.Play ();
		gameModeText.text = mode;
		this.mode = mode;

		modeSelection.SetActive (false);
		playerSelection.SetActive (true);
		playerSelectionFirstItem.Select ();
		playerSelectionFirstItem.OnSelect (null);
	}

	/** Players selection menu **/

	public void PlayerSelectionGoBack(){
		accept.Play ();
		playerSelection.SetActive (false);
		modeSelection.SetActive (true);
		modeSelectionFirstItem.Select ();
		modeSelectionFirstItem.OnSelect (null);
	}

	public void SetPlayerQuantity(int quantity){
		accept.Play ();
		PlayerPrefs.SetInt ("PlayerQuantity", quantity);

		if (mode.Equals ("death race")) {
			PlayerPrefs.SetString ("SceneToLoad", "SwiftnessTrack");	
			anim.SetTrigger ("FadeOut");
			afader.Fade();
			//Fade out
			//SceneManager.LoadScene ("LevelLoader");
		} else if (mode.Equals ("death ball")) {
			PlayerPrefs.SetString ("SceneToLoad", "LeagueTesting");	
			//Fade out
			SceneManager.LoadScene ("LevelLoader");
				
		} else if (mode.Equals ("death match")) {
			//Do it.
		}
	}

	private void CalculateMaxPlayersQuantity(){
		Debug.Log (Input.GetJoystickNames ().Length);
		if (Input.GetJoystickNames ().Length < 4) {
			playersButton4.interactable = false;
		} else {
			playersButton4.interactable = true;
		}
		if (Input.GetJoystickNames ().Length < 3) {
			playersButton3.interactable = false;
		} else {
			playersButton3.interactable = true;
		}


	}

	//death race
	//death ball
	//death match



}
