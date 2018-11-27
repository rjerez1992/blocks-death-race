using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandMiner : MonoBehaviour {

	public Rigidbody mine;
	public int damage = 40;
	public Transform spawnPoint;
	public int maxAmmo = 3;
	public int currentAmmo = 3;
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
		weaponText.text = "Landmine";
		weaponQuantity.text = "x" + currentAmmo;
	}

	void OnDisable(){
		weaponBar.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(fireButton) && currentAmmo > 0) {
			gameObject.GetComponent<AudioSource> ().Play ();
			var mineobject =Instantiate (mine, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
			//mineobject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 1, 0));
			mineobject.GetComponent<LandMine> ().mineDamage = damage;
			currentAmmo--;
			weaponQuantity.text = "x" + currentAmmo;
			if (currentAmmo < 1) {	
				//TODO: Add dissapear animation
				gameObject.SetActive (false);
			}
		}
	}
}
