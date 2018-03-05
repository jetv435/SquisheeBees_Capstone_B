using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ALLOW_OR_PREVENT
{
	ALLOW,
	LOCK

}

public class MG3_KeyActivator : MonoBehaviour {

	//This is to grab game object that are similar to this one, and have the same "exception" key. or similar whichArrowKeyToActivate.
	public List<GameObject> similarObjectsSameExceptionKey = new List<GameObject>();

	public string whichArrowKeyToActivate = "Right";
	GameObject playerObject;
	MG3and4_MovementScript keyAllowanceScript;

	public ALLOW_OR_PREVENT activatorOrDisabler = ALLOW_OR_PREVENT.ALLOW;

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
		if (activatorOrDisabler == ALLOW_OR_PREVENT.ALLOW) {

			keyAllowanceScript.KeyAllower ();
			for (int i = 0; i < similarObjectsSameExceptionKey.Count; i++) {
				similarObjectsSameExceptionKey [i].GetComponent<SpriteRenderer> ().enabled = false;
			}
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		} else {
			keyAllowanceScript.KeyLocking (whichArrowKeyToActivate);
			for (int i = 0; i < similarObjectsSameExceptionKey.Count; i++) {
				similarObjectsSameExceptionKey [i].SetActive (false);
			}
			gameObject.SetActive (false);
		}
	}
}
