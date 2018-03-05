using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3_BoxBlockRemovalScript : MonoBehaviour {

	public GameObject boxBlockObject;
	MG3_BoxBlockScript blockScript;

	// Use this for initialization
	void Start () {

		blockScript = boxBlockObject.GetComponent<MG3_BoxBlockScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		blockScript.DisappearingBoxFunction ();
		gameObject.SetActive (false);
	}
}
