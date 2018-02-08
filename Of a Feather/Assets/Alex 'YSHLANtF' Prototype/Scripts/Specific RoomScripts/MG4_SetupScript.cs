using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG4_SetupScript : MonoBehaviour {

	GameObject playerObject;
	MG3and4_MovementScript keyAllowanceScript;

	// Use this for initialization
	void Start () {

		playerObject = GameObject.FindGameObjectWithTag ("Player");
		keyAllowanceScript = playerObject.GetComponent<MG3and4_MovementScript> ();

		keyAllowanceScript.ActivateKey ("Right");
		keyAllowanceScript.ActivateKey ("Up");
		keyAllowanceScript.ActivateKey ("Left");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
