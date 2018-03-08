using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leavingbasement : MonoBehaviour {

	MainMenuManager mm;

	// Use this for initialization
	void Start () {
		mm = GameObject.FindObjectOfType<MainMenuManager> ().GetComponent<MainMenuManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			StartCoroutine (mm.SGCorutine ());
		}

	}
}
