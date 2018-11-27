using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StadiumMatchController : MonoBehaviour {

	public Text team0Scoreboard;
	public Text team1Scoreboard;
	public int team0Score = 0;
	public int team1Score = 0;
	public int startCountdown = 3;
	public Text gameTimer;
	public int gameTimeSeconds = 300;
	public bool gameRunning = false;
	private float startingTime;
	private float currentTime;
	public Transform ballStartingPosition;
	public GameObject ball;

	public GameObject playerRed;
	public GameObject playerBlue;
	public Transform playerRedStartingPos;
	public Transform playerBlueStartingPos;
	public GameObject playerRed2;
	public GameObject playerBlue2;
	public Transform playerRedStartingPos2;
	public Transform playerBlueStartingPos2;


	// Use this for initialization
	void Start () {
		//DoStartupThing
		startingTime = Time.time;
		startupPositions ();
		playerRed.GetComponent<CarController> ().Unrestrain ();
		playerRed2.GetComponent<CarController> ().Unrestrain ();
		playerBlue.GetComponent<CarController> ().Unrestrain ();
		playerBlue2.GetComponent<CarController> ().Unrestrain ();
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer ();

	}

	public void maskScore(int teamNumber){
		if (teamNumber == 0) {
			team0Score++;
		} else {
			team1Score++;
		}
		this.updateScoreboard ();
		this.startupPositions ();

	}

	void updateScoreboard(){
		team0Scoreboard.text = "Blue: " + team0Score;
		team1Scoreboard.text = "Red: " + team1Score;
	}


	void startupPositions(){/*
		ball.transform.position = ballStartingPosition.position;
		ball.transform.rotation = ballStartingPosition.rotation;
		ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		ball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;*/
		playerRed.GetComponent<TurboBoost> ().EmptyTurbo ();
		playerBlue.GetComponent<TurboBoost> ().EmptyTurbo ();
		playerRed2.GetComponent<TurboBoost> ().EmptyTurbo ();
		playerBlue2.GetComponent<TurboBoost> ().EmptyTurbo ();
		setupObjectAt (ball, ballStartingPosition);
		setupObjectAt (playerRed, playerRedStartingPos);
		setupObjectAt (playerBlue, playerBlueStartingPos);
		setupObjectAt (playerRed2, playerRedStartingPos2);
		setupObjectAt (playerBlue2, playerBlueStartingPos2);
	}

	void setupObjectAt(GameObject ob, Transform pos){
		ob.transform.position = pos.position;
		ob.transform.rotation = pos.rotation;
		ob.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		ob.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}



	void updateTimer(){
		currentTime = Time.time;
		int totalSeconds = (int)(currentTime - startingTime);
		int remainingTime = gameTimeSeconds - totalSeconds;
		this.gameTimer.text = remainingTime / 60 + ":" + remainingTime % 60;
	}

}
