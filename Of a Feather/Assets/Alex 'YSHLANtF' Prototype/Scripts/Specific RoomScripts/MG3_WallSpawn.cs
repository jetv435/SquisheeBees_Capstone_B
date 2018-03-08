using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3_WallSpawn : MonoBehaviour {

	public GameObject wallObject;

	// Use this for initialization
	void Start () {

		wallObject.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		wallObject.SetActive (true);
	}
}
