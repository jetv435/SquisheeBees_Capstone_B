using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3_BoxRemoveScriptVersion2 : MonoBehaviour {

	public List<GameObject> wallObjects = new List<GameObject>();
	int activeCounter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < wallObjects.Count; i++) {
			if (wallObjects [i].activeSelf == true) {
				activeCounter++;
			}
		}

		if (activeCounter >= wallObjects.Count) {
			gameObject.SetActive (false);
		} else {
			activeCounter = 0;
		}
		
	}
}
