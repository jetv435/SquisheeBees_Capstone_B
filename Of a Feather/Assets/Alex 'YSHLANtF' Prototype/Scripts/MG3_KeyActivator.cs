using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3_KeyActivator : MonoBehaviour {

	public string whichArrowKeyToActivate = "Right";
	GameObject playerObject;
	MG3and4_MovementScript keyAllowanceScript;

	// Use this for initialization
	void Start () {

		playerObject = GameObject.FindGameObjectWithTag ("Player");
		keyAllowanceScript = playerObject.GetComponent<MG3and4_MovementScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		keyAllowanceScript.ActivateKey (whichArrowKeyToActivate);
	}
}
