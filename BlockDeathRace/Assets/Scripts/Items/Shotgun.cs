using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour {

	[Header("WeaponProps")]
	public int damage = 45;
	public int speed = 250;
	public float lifeSpan = 3.0f;
	public int maxAmmo = 2;
	public int currentAmmo = 2;

	[Header("Objects")]
	public GameObject bullet;
	public Transform spawnPoint;
	public ParticleSystem fireAnimation; //Maybe spawn it with the bullet?
	public WeaponUI weaponUI;
	public PlayerInput playerInput;
	public AudioSource shootAudio;

	// Use this for initialization
	void Start () {

	}

	void OnEnable(){
		currentAmmo = maxAmmo;
		weaponUI.weaponBar.SetActive (true);
		weaponUI.weaponQuantity.text = "x" + currentAmmo;
		weaponUI.weaponName.text = "Shotgun";
	}

	void OnDisable(){
		weaponUI.weaponBar.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(playerInput.fireButton) && currentAmmo > 0) {
			//gameObject.GetComponent<AudioSource> ().Play ();
			fireAnimation.Play();
			shootAudio.Play ();

			var rocket = (GameObject)Instantiate (bullet, spawnPoint.position, spawnPoint.rotation);
			rocket.GetComponent<DamageColiision> ().damage = damage;
			rocket.GetComponent<Rigidbody> ().velocity = rocket.transform.forward * -speed;
			Destroy (rocket, lifeSpan);
					
			currentAmmo--;
			weaponUI.weaponQuantity.text = "x" + currentAmmo;

			if (currentAmmo < 1) {
				gameObject.SetActive (false);
			}
		}	
	}
}
