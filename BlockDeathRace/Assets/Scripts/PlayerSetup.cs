using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	// Use this for initialization
	void Start () {
		int playerQuantity = PlayerPrefs.GetInt ("PlayerQuantity");
		//Debug.Log (playerQuantity);
		if (playerQuantity == 2) {
			foreach (Camera c in player1.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0f, 0.5f, 1f, 0.5f);
			}
			player2.SetActive (true);
			foreach (Camera c in player2.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0f, 0f, 1f, 0.5f);
			}
		}
		else if (playerQuantity == 3) {
			foreach (Camera c in player1.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0f, 0.5f, 1f, 0.5f);
			}
			player2.SetActive (true);
			foreach (Camera c in player2.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0f, 0f, 0.5f, 0.5f);
			}
			player3.SetActive (true);
			foreach (Camera c in player3.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0.5f, 0f, 0.5f, 0.5f);
			}
		}
		else if (playerQuantity == 4) {
			foreach (Camera c in player1.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0f, 0.5f, 0.5f, 0.5f);
			}
			player2.SetActive (true);
			foreach (Camera c in player2.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0.5f, 0.5f, 0.5f, 0.5f);
			}
			player3.SetActive (true);
			foreach (Camera c in player3.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0f, 0f, 0.5f, 0.5f);
			}
			player4.SetActive (true);
			foreach (Camera c in player4.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0.5f, 0f, 0.5f, 0.5f);
			}
		} 
		else {
			foreach (Camera c in player1.GetComponentsInChildren<Camera>(true)) {
				c.rect = new Rect (0, 0, 1, 1);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
