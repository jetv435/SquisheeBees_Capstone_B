using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3_PlayerRespawn : MonoBehaviour {

	GameObject playerObject;

	Vector3 oriPos;

	// Use this for initialization
	void Start () {

		playerObject = GameObject.FindGameObjectWithTag ("Player");

		oriPos = playerObject.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		playerObject.transform.position = oriPos;
	}
}
