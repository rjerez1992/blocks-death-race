using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour {

	public static float maxHealth = 100;
	public float currentHealth = 100;
	public bool isShielded = false;
	public GameObject lowDamageAnim;
	public GameObject highDamageAnim;
	private int lowDamageThreshold = 60;
	private int highDamageThreshold = 30;
	public GameObject deathExplosion;
	public Slider healthText;
	public Rigidbody body;
	private bool broken = false;
	public float respawnTime = 5;
	private float startRespawnTime;
	public GameObject brokenEffect;
	public Text repairingText;



	// Use this for initialization
	void Start () {
		healthText.value = currentHealth/maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (broken) {
			int elapsedTime = (int)(Time.time - startRespawnTime);
			if (elapsedTime > respawnTime) {
				//Add broken and repairing animation
				//Disable colliders?
				broken = false;
				currentHealth = maxHealth;
				healthText.value = currentHealth/maxHealth;
				brokenEffect.SetActive (false);
				lowDamageAnim.SetActive (false);
				highDamageAnim.SetActive (false);
				repairingText.gameObject.SetActive (false);


			} else {
				currentHealth = maxHealth * (elapsedTime / respawnTime);
				healthText.value = currentHealth/maxHealth;
				body.velocity = Vector3.zero;
				//healthText.text = "Respawning " + (respawnTime-elapsedTime);
			}

				
		}
	}

	public void Heal(int amount){
		this.currentHealth += amount;
		this.SetDamageAnimation ();
		if (currentHealth > maxHealth) {
			this.currentHealth = maxHealth;
		}
		healthText.value = currentHealth/maxHealth;
	}

	public void Shield(){
		this.isShielded = true;
	}

	public void Unshield(){
		this.isShielded = false;
	}

	public void DoDamage(int amount){

		//RETURN BOOLEAN AND CHECK IF DID DAMAGE.
		currentHealth -= amount;
		this.SetDamageAnimation ();
		if (currentHealth <= 0) {
			currentHealth = 0;
			healthText.value = currentHealth/maxHealth;
			var effect = (GameObject)Instantiate (deathExplosion, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (effect, 3.0f);
			body.velocity = Vector3.zero;
			//Destroy (gameObject);
			broken = true;
			//healthText.text = "Respawning " +respawnTime;
			startRespawnTime = Time.time;
			brokenEffect.SetActive (true);
			repairingText.gameObject.SetActive (true);
			DestroyWeapon ();
			return;
		}
		healthText.value = currentHealth/maxHealth;
	}

	public void SetDamageAnimation(){
		if (currentHealth < highDamageThreshold) {
			lowDamageAnim.SetActive (true);
			highDamageAnim.SetActive (true);
		} else if (currentHealth < lowDamageThreshold) {
			lowDamageAnim.SetActive (true);
		} else {
			lowDamageAnim.SetActive (false);
			highDamageAnim.SetActive (false);
		}
	}

	public void DestroyWeapon(){
		WeaponManager wm = gameObject.GetComponent<WeaponManager> ();
		wm.DisableWeapon ();
	}
}
