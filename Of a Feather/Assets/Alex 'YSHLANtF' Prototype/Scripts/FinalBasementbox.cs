using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBasementbox : MonoBehaviour {


	//public List<GameObject> specialobjects = new List<GameObject>();

	PickupPlayerScript PuPs;

	public GameObject specialobj;
	public GameObject specialobj1;
	public GameObject specialobj2;
	public GameObject binopen;
	public GameObject binclose;
	public GameObject finale;


	int itemsneeded;
	public int itemshave;
	int timer = 120;

	//DialogManager dialogue;
	dialogReader dr;




	// Use this for initialization
	void Start () {

		PuPs = GameObject.FindObjectOfType<PickupPlayerScript> ().GetComponent<PickupPlayerScript> ();
		//dialogue = GameObject.FindObjectOfType<DialogManager> ().GetComponent<DialogManager> ();
		dr = GameObject.FindObjectOfType<dialogReader> ().GetComponent<dialogReader> ();




		//for (int i = 0; i < specialobjects.Count; i++) {
			//specialobjects [i].SetActive (false);

		//}
		specialobj.SetActive(false);
		specialobj1.SetActive (false);
		specialobj2.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (itemshave >= 3) {
			binopen.SetActive (false);
			binclose.SetActive (true);
			timer--;
			if (timer <= 0) {
				finale.SetActive (true);
			}
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "box") {

			specialobj2.SetActive (true);
			PuPs.carriedObj.SetActive (false);
			itemshave++;
			if (itemshave == 1) {
				dr.startline = 141;
				dr.readlines ();
			} else if (itemshave == 2) {
				dr.startline = 142;
				dr.readlines ();
			} else if (itemshave == 3) {
				dr.startline = 144;
				dr.readlines ();
			}

		} else if (other.tag == "cubebox") {
			
			specialobj.SetActive (true);
			PuPs.carriedObj.SetActive (false);
			itemshave++;
			if (itemshave == 1) {
				dr.startline = 141;
				dr.readlines ();
			} else if (itemshave == 2) {
				dr.startline = 142;
				dr.readlines ();
			} else if (itemshave == 3) {
				dr.startline = 144;
				dr.readlines ();
			} 

		} else if (other.tag == "jar") {

			specialobj1.SetActive (true);
			PuPs.carriedObj.SetActive (false);
			itemshave++;
			if (itemshave == 1) {
				dr.startline = 141;
				dr.readlines ();
			} else if (itemshave == 2) {
				dr.startline = 142;
				dr.readlines ();
			} else if (itemshave == 3) {
				dr.startline = 144;
				dr.readlines ();
			} 
		}
			/*for (int i = 0; i < specialobjects.Count; i++) {
				if (specialobjects [i].tag == PuPs.carriedObj.tag) {
					specialobjects [i].SetActive (true);
					PuPs.carriedObj.SetActive (false);
					return;
				}
			} */
		}


}