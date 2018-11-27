using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpace : MonoBehaviour {

	public GameObject anim;
	public int teamGoalSpace = 0;  //0 Blue - 1 Red
	public StadiumMatchController smt;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name.Equals("GameBall")){			
			var animation = (GameObject)Instantiate (anim, col.transform.position, col.transform.rotation);
			animation.SetActive (true);
			smt.maskScore (teamGoalSpace);
			Destroy (animation, 3.0f);
		}
	}
}
