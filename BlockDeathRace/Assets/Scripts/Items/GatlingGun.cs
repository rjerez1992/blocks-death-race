using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatlingGun : MonoBehaviour {

	public GameObject bulletPrefab;
	public int damage = 5;
	public List<Transform> bulletSpawns;
	public int bulletSpeed = 400;
	public float bulletLifeSpan = 1.0f;
	public float fireRate = 1;
	public float lastShoot;
	public GameObject fireAnimation;
	public int ammo = 50;
	public int maxAmmo = 50;
	public Text weaponName;
	public Text weaponQuantity;
	//public Slider weaponSlider;
	public GameObject weaponBar;
	public string playerController =  "J1";
	private string fireButton = "Fire";

	// Use this for initialization
	void Start () {
		lastShoot = Time.time;	
		fireButton += playerController;
	}

	void OnEnable(){
		lastShoot = Time.time;	
		ammo = maxAmmo;
		weaponBar.SetActive (true);
		weaponName.text = "Gatling";
		weaponQuantity.text = "x" + ammo;
	}

	void OnDisable(){
		weaponBar.SetActive (false);
	}

	// Update is called once per frame
	void Update () {		
		if (Input.GetButton(fireButton)) {
			if (Time.time - lastShoot > fireRate) {		
				lastShoot = Time.time;
				Transform bulletSpawn = bulletSpawns [Random.Range (0, bulletSpawns.Count)];
				var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
				bullet.GetComponent<DamageColiision> ().damage = damage;
				bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.up * -bulletSpeed;
				Destroy (bullet, bulletLifeSpan);

				fireAnimation.SetActive (true);
				ammo--;
				//TODO: Change in another way
				if (ammo < 1) {						
					gameObject.SetActive (false);
				}
				weaponQuantity.text = "x"+ammo;			
			} 
		}
		else {
			fireAnimation.SetActive (false);
		}
	}


}
