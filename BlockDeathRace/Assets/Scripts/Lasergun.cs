using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergun : MonoBehaviour {

	[Header("WeaponProps")]
	public int damage = 90;
	public int speed = 250;
	public float lifeSpan = 3.0f;
	public int maxAmmo = 2;
	public int currentAmmo = 2;
	public float chargeTime = 2f;

	[Header("Objects")]
	public GameObject bullet;
	public Transform spawnPoint;
	public GameObject chargeAnimation; 
	public WeaponUI weaponUI;
	public PlayerInput playerInput;
	public ParticleSystem shootAnim;
	public AudioSource shootAudio;

	private bool isCharging = false;
	private float startCharge;

	// Use this for initialization
	void Start () {

	}

	void OnEnable(){
		currentAmmo = maxAmmo;
		weaponUI.weaponBar.SetActive (true);
		weaponUI.weaponQuantity.text = "x" + currentAmmo;
		weaponUI.weaponName.text = "Laser";
	}

	void OnDisable(){
		weaponUI.weaponBar.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (isCharging) {
			if (Time.time - startCharge > chargeTime) {
				isCharging = false;
				chargeAnimation.SetActive (false);
				shoot ();
			}
		}


		if (Input.GetButtonDown(playerInput.fireButton) && currentAmmo > 0) {
			isCharging = true;
			chargeAnimation.SetActive (true);
			startCharge = Time.time;

		}	
		else if (Input.GetButtonUp(playerInput.fireButton)){
			isCharging = false;
			chargeAnimation.SetActive (false);
		}
	}

	void shoot(){
		shootAudio.Play ();
		shootAnim.Play ();

		var rocket = (GameObject)Instantiate (bullet, spawnPoint.position, spawnPoint.rotation);
		rocket.GetComponent<DamageColiision> ().damage = damage;
		rocket.GetComponent<Rigidbody> ().velocity = rocket.transform.up * speed;
		Destroy (rocket, lifeSpan);

		currentAmmo--;
		weaponUI.weaponQuantity.text = "x" + currentAmmo;

		if (currentAmmo < 1) {
			gameObject.SetActive (false);
		}
	}
}
