using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboBoost : MonoBehaviour {

	public int turboForce = 100;
	public int maxTurbo = 2000;
	public int remainTurbo =0;
	public int turboRegain = 1;
	public Slider turboSlider;
	public GameObject turboObject;
	public string playerController =  "J1";
	private string turboButton = "Turbo";
	public int startingTurbo = 2000;



	// Use this for initialization
	void Start () {
		remainTurbo = maxTurbo;
		turboSlider.maxValue = maxTurbo;
		turboSlider.minValue = 0;
		turboSlider.wholeNumbers = true;
		turboButton += playerController;
		if (startingTurbo < maxTurbo) {
			remainTurbo = startingTurbo;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton(turboButton)) {
			if (remainTurbo >= 100) {				
				remainTurbo -= 10;
				//TODO: Disable boost to make vehicle fly
				Vector3 vel = gameObject.GetComponent<Rigidbody> ().velocity.normalized;
				vel.Scale (new Vector3 (1, 0, 1));
				gameObject.GetComponent<Rigidbody> ().AddForce (vel * turboForce, ForceMode.Acceleration);
				turboObject.SetActive (true);
				//wheelController.isTurbo = true;
			} else {
				turboObject.SetActive (false);
				//wheelController.isTurbo = false;
			}
		} else {			
			if (remainTurbo < maxTurbo) {
				remainTurbo += turboRegain;
				turboObject.SetActive (false);
				//wheelController.isTurbo = false;;
			}
		}
		turboSlider.value = remainTurbo;
	}



	public void Refill(int amount){
		remainTurbo += amount;
		if (remainTurbo > maxTurbo) {
			remainTurbo = maxTurbo;
		}
	}

	public void EmptyTurbo(){
		this.remainTurbo = 0;
	}
}
