using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class RaceController : MonoBehaviour {
	
	public class RacerTracker{
		public string racerName;
		public int checkPointReached = 0;
		public int lapCount = 1;
		public Text lapCounter;
		public Text positionText;
		public Text centerText;
		public Text maxLaps;
		public CarController carControl;
		public bool won = false;	
	

		[HideInInspector]
		public int playerPosition = 0;

		public RacerTracker(string racerName, Text lapCounter, Text positionText, Text centerText,Text maxLaps,CarController cc){
			this.racerName = racerName;
			this.checkPointReached = 0;
			this.lapCount = 1;
			this.lapCounter = lapCounter;
			this.positionText = positionText;
			this.carControl = cc;
			this.centerText = centerText;
			this.maxLaps = maxLaps;
			this.won = false;
		}

		public int GetRawValue(){
			//Debug.Log(racerName + "VALUE: "+(this.checkPointReached+1)+(1000*this.lapCount+1));
			return (this.checkPointReached+1)+(1000*this.lapCount+1);

		}
	}

	public List<RacerTracker> players = new List<RacerTracker>();	
	public int LapQuantity = 5;
	public int CheckPointQuantity = 10;
	public bool racing = false;
	//public Text RaceText;
	//public GameObject startCage;
	public GameObject startBackground;
	public Text startText;
	public int startCount = 3;
	public float startTime;
	public int lastCountNumber = 4;
	public Text winText;
	private bool ended = false;
	public AudioSource raceMusic;
	public bool raceStarted = false;
	public AudioSource winMusic;
	public bool firstWinner = false;
	public AudioFader afader;
	public PauseMenu pmenu;

	// Use this for initialization
	void Start () {

		racing = false;
		ended = false;
		raceStarted = false;
		firstWinner = false;
		//players = new List<RacerTracker>();	
		//this.StopAllRacers ();

		//RaceText.text = "Swiftness - " + LapQuantity + " laps to win";
		//TODO: Start countdown.

		//this.StopAllRacers ();
	}
	
	// Update is called once per frame
	void Update () {		
		if (!racing && !ended && raceStarted) {
			if (Time.time - startTime >= startCount) {
				racing = true;
				UnstopAllRacers ();
				startText.text = "Race on!";
				startText.gameObject.GetComponent<AudioSource> ().pitch += 0.5f;
				startText.gameObject.GetComponent<AudioSource> ().Play ();
				Destroy (startText.gameObject, 0.5f); //Dont destroy it. Use it later?
				Destroy (startBackground, 0.5f);
				raceMusic.Play ();

			} 
			else {
				int count = startCount - (int)(Time.time - startTime);
				startText.text = count + "";
				if (count < lastCountNumber) {
					//racing = true;
					lastCountNumber--;				
					startText.gameObject.GetComponent<AudioSource> ().Play ();
				}
			} 
		}
	}

	public void subscribePlayer(string name, Text lapCounter, Text positionText, Text centerText, Text maxLaps,CarController cc){
		this.players.Add (new RacerTracker (name, lapCounter, positionText, centerText,  maxLaps,cc));
		this.UpdateText ();
		maxLaps.text = "/"+this.LapQuantity;
	}

	public void checkPoint(int number, string playerName){
		/*if (!racing) {			
			return;
		}*/
		foreach(RacerTracker tracker in players){
			if (tracker.racerName.Equals(playerName)) {
				if (tracker.won) {
					//If player won we won't count any more checkpoints
					return;
				}

				if (number == tracker.checkPointReached+1){
					tracker.checkPointReached++;
				}

				if (tracker.lapCount >= LapQuantity+1){
					//tracker.lapCount--;
					tracker.centerText.gameObject.SetActive (true);
					tracker.centerText.text = "#"+tracker.playerPosition+ " place!";
					tracker.lapCounter.gameObject.SetActive (false);

					//////////////FIX THE LAP COUNTER WHEN WINNING... SOMEHOW.

					//racing = false;
					//ended = true;
					tracker.won = true;
					//tracker.carControl.DeactivateMovementAndCollision ();	
					//tracker.positionText.text = "";
				

					////////////LOCK POSITION and DISABLE COLLIDERS WHEN WON: (or make it dissapear?)

					if (!firstWinner) {
						afader.Fade ();
						firstWinner = true;
						winMusic.gameObject.SetActive (true);
					}



					if (raceFinished()) {
						//SHOW MENU TO PLAY AGAIN OR EXIT OR CHANGE MAP EVENTUALLY OR NEXT?
						ended = true;
						//pmenu.RaceFinishMenu ();
						StartCoroutine(finishRace());

						//SceneManager.LoadScene ("Menu");
					
					}

				
				}
				else if (tracker.checkPointReached >= CheckPointQuantity) {
					//Debug.Log ("ADDED");
					tracker.lapCount++;
					tracker.checkPointReached = 0;
				}
			}
		}
		this.UpdateText ();
	}

	//ADD THE POSITION TO THE RACE TRACKER . LOCK THE POSITION!!!!! SOMEHOW WHEN FINISHING THE RACE!!!
	//ADD CHECKPOINTS TO THE TRACKER BY THE QUANTITY OF PLAYER MINUS THE POSITION (so first player would get x3 )


	public void UpdateText(){
		//RaceText.text = "Swiftness - " + LapQuantity + " laps to win";
		players = players.OrderByDescending (x => x.GetRawValue()).ToList();	
		for (int i = 0; i < players.Count; i++) {
			RacerTracker rt = players [i];
			rt.lapCounter.text = rt.lapCount+"";
			rt.positionText.text = (i + 1) + "";
			rt.playerPosition = i + 1;
		}			
	}

	public void StopAllRacers(){
		foreach (RacerTracker rt in players) {
			rt.carControl.Restrain ();
		}
	}

	public void UnstopAllRacers(){
		//Debug.Log ("Unstopping....");
		//Debug.Log (players.Count);
		foreach (RacerTracker rt in players) {
			//Debug.Log ("UNRESTRAINING");
			rt.carControl.Unrestrain ();
		}
	}

	public bool raceFinished(){
		foreach (RacerTracker tracker in players) {
			if (!tracker.won) {
				return false;
			}
		}
		return true;
	}


	public void startRace(){
		this.raceStarted = true;
		startTime = Time.time;
		startText.gameObject.SetActive (true);
		startBackground.SetActive (true);

	}


	public IEnumerator finishRace(){
		yield return new WaitForSeconds (3);
		pmenu.RaceFinishMenu ();
	}
}
