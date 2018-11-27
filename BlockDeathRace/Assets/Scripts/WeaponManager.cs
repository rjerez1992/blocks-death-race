using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

	public List<GameObject> weapons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisableWeapon(){		
		foreach (GameObject go in weapons) {
			go.SetActive (false);
		}
	}

	public void NewRandomWeapon(){
		DisableWeapon ();
		weapons [Random.Range (0, weapons.Count)].SetActive (true);
	}
}
