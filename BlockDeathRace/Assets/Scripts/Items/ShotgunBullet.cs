using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour {

	public float sizeMultiplier = 1;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bullet.transform.localScale += new Vector3(1, 0, 0) * (Time.deltaTime * sizeMultiplier);
	}
}
