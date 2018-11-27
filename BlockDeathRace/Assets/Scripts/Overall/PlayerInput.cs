using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public string playerController = "J1";
	public string jumpButton = "Jump";
	public string turboButton = "Turbo";
	public string reverseButton = "Reverse";
	public string accelerateButton = "Accelerate";
	public string horizontalButton = "Horizontal";
	public string horizontalKey = "KeyHorizontal";
	public string brakeButton = "Brake";
	public string fireButton = "Fire";
	public string verticalAxis = "Vertical";

	// Use this for initialization
	void Start () {
		jumpButton += playerController;
		turboButton += playerController;
		reverseButton += playerController;
		accelerateButton += playerController;
		horizontalButton += playerController;
		horizontalKey += playerController;
		brakeButton += playerController;
		fireButton += playerController;
		verticalAxis += playerController;
	}

	/*
	// Update is called once per frame
	void Update () {
		
	}*/
}
