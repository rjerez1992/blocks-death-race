using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class WheelAxle : System.Object
{
	public WheelCollider leftWheel;
	public GameObject leftWheelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWheelMesh;
	public bool motor;
	public bool steering;
	public bool reverseTurn;
}

public class CarController : MonoBehaviour {
	[Header("Control")]
	public PlayerInput playerInput;

	[Header("Engine")]
	public float maxMotorTorque;
	public float maxSteeringAngle;
	public float brakePower = 1;
	public float maxSpeed = 90;
	public List<WheelAxle> CarAxles;
	public int jumpForce = 15;

	[Header("Effects")]
	public GameObject brakeEffect;
	public AudioSource jumpEffect;

	[HideInInspector]
	public bool isTurbo = false;

	//private float directionMultiplier = 0;
	private Rigidbody body; 
	private bool isRestrained = true;

	private bool jumped = false;

	public void VisualizeWheel(WheelAxle wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.leftWheel.GetWorldPose ( out pos, out rot);
		wheelPair.leftWheelMesh.transform.position = pos;
		wheelPair.leftWheelMesh.transform.rotation = rot;
		wheelPair.rightWheel.GetWorldPose ( out pos, out rot);
		wheelPair.rightWheelMesh.transform.position = pos;
		wheelPair.rightWheelMesh.transform.rotation = rot;
	}

	public void Start(){		
		body = gameObject.GetComponent<Rigidbody> ();
	}

	public void Update()
	{
		if (isRestrained) {	
			foreach (WheelAxle wheelAxle in CarAxles)
			{			
				wheelAxle.leftWheel.brakeTorque = maxMotorTorque*10;
				wheelAxle.rightWheel.brakeTorque = maxMotorTorque*10;
				VisualizeWheel(wheelAxle);

			}
			return;
		}


		if (jumped) {
			resetJump ();
		}

		if (Input.GetButtonDown (playerInput.jumpButton)) {
			this.Jump ();
		}	

		float motor = maxMotorTorque * Input.GetAxis (playerInput.verticalAxis); //* directionMultiplier;

		/*if (isTurbo) {
			
			motor *= (2);
		}*/

		float steering = ((100/(body.velocity.magnitude+10))*maxSteeringAngle) * Input.GetAxis(playerInput.horizontalButton);

		/*
		if (Input.GetAxis(playerInput.horizontalKey) != 0){
			steering = ((100/(body.velocity.magnitude+10))*maxSteeringAngle) * Input.GetAxis(playerInput.horizontalKey);
		}*/


		float brakeTorque = 0;

		if (Input.GetButton(playerInput.brakeButton)) {
			brakeTorque = maxMotorTorque;
			motor = 0;
			if (body.velocity.magnitude > 10) {
				brakeEffect.SetActive (true);
			} else {
				brakeEffect.SetActive (false);
			}
		} 
		else {
			brakeEffect.SetActive (false);
		}

		foreach (WheelAxle wheelAxle in CarAxles)
		{
			if (wheelAxle.steering == true) {
				wheelAxle.leftWheel.steerAngle = wheelAxle.rightWheel.steerAngle = ((wheelAxle.reverseTurn)?-1:1)*steering;
			}

			if (wheelAxle.motor == true)
			{
				if (!isTurbo && body.velocity.magnitude > maxSpeed-1) {
					wheelAxle.leftWheel.motorTorque = -motor/3;
					wheelAxle.rightWheel.motorTorque = -motor/3;
				} else {
					wheelAxle.leftWheel.motorTorque = motor;
					wheelAxle.rightWheel.motorTorque = motor;
				}
			}

			wheelAxle.leftWheel.brakeTorque = brakeTorque * brakePower;
			wheelAxle.rightWheel.brakeTorque = brakeTorque * brakePower;

			VisualizeWheel(wheelAxle);



		}

	
	

		//rpm.text = (int)(CarAxles [0].rightWheel.rpm*CarAxles [0].leftWheel.radius*6.3f) + "RPM";

	}

	public void Jump(){
		if (!jumped) {
			body.AddForce (gameObject.transform.up * jumpForce, ForceMode.VelocityChange);
			jumpEffect.Play ();
			jumped = true;
		}	
	}

	public void resetJump(){
		if (CarAxles [0].leftWheel.isGrounded && CarAxles [0].rightWheel.isGrounded) {
			
			jumped = false;
		}
		/*
		if (gameObject.transform.position.y <= 1.1) {
			jumped = false;
			doubleJumped = false;
		}*/
	}

	public void Restrain(){
		this.isRestrained = true;
	}

	public void Unrestrain(){
		//Debug.Log ("UNRESTRAINED");
		this.isRestrained = false;
	}

	public void DeactivateMovementAndCollision(){
		this.Restrain ();	
	}
	

}