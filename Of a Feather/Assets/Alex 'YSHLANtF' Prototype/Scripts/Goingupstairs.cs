using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goingupstairs : MonoBehaviour {

	public GameObject oldbin;
	public GameObject newbin;

	public Collider getrid;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		oldbin.SetActive (false);
		newbin.SetActive (true);
		getrid.enabled = false;
		
	}

	void hold(){



	}
}
