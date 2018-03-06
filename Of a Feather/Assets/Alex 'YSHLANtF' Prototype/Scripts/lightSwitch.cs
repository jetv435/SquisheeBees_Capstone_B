using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour {

	public List<GameObject> Lights = new List<GameObject>();
	AudioManager am;

	bool ison = true;

	bool inArea = false;

	// Use this for initialization
	void Start () {

		am = GameObject.FindObjectOfType<AudioManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (ison && inArea == true) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {

				Turnoff ();
			}
		}

		else if(Input.GetKeyDown(KeyCode.Mouse0) && inArea == true){


			Turnon();
		
		}
		
	}


	void Turnoff(){

		for (int i = 0; i < Lights.Count; i++) {
			Lights [i].SetActive (false);

		}
		ison = false;
		am.SoundEffects [1].Play ();


	}


	void Turnon(){

		for (int i = 0; i < Lights.Count; i++) {
			Lights [i].SetActive (true);

		}
		ison = true;
		am.SoundEffects [0].Play ();

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {

			inArea = true;



		}
	}

	void OnTriggerExit(Collider other){

		inArea = false;

	}

		
}
