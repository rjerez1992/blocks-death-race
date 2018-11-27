using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour {

	public GameObject rocketPrefab;
	public int damage = 40;
	public Transform rocketSpawnPoint;
	public int rocketSpeed = 275;
	public float rocketLifeSpan = 3.0f;
	public int maxAmmo = 5;
	public int currentAmmo = 5;
	public Text weaponText;
	//public Slider weaponSlider;
	public Text weaponQuantity;
	public GameObject weaponBar;
	public string playerController =  "J1";
	private string fireButton = "Fire";

	// Use this for initialization
	void Start () {
		fireButton += playerController;
	}

	void OnEnable(){
		currentAmmo = maxAmmo;

		weaponBar.SetActive (true);
		weaponQuantity.text = "x" + currentAmmo;
		weaponText.text = "Rocket L.";
	}

	void OnDisable(){
		weaponBar.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(fireButton) && currentAmmo > 0) {
			gameObject.GetComponent<AudioSource> ().Play ();
			var rocket = (GameObject)Instantiate (rocketPrefab, rocketSpawnPoint.position, rocketSpawnPoint.rotation);
			rocket.GetComponent<DamageColiision> ().damage = damage;
			rocket.GetComponent<Rigidbody> ().velocity = rocket.transform.up * -rocketSpeed;
			Destroy (rocket, rocketLifeSpan);
			currentAmmo--;
			weaponQuantity.text = "x" + currentAmmo;
			if (currentAmmo < 1) {
				gameObject.SetActive (false);
			}
		}
	}
}
