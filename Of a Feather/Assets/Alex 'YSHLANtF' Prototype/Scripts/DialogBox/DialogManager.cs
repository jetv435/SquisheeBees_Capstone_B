using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public Text storyitem;

	public GameObject dialogbox;

	private Queue<string> description;
	// Use this for initialization
	void Start () {

		description = new Queue<string> ();
		dialogbox.SetActive (false);
	}

	public void startstory(Storylines story){

		Debug.Log ("testing");

		description.Clear ();
		foreach (string descrip in story.description) {

			description.Enqueue (descrip);
		}
		displaydescription ();


	}

	void displaydescription(){

		if (description.Count == 0) {
			enddisplay ();
			return;
		}
		string descrip = description.Dequeue ();
		storyitem.text = descrip;
	}

	void enddisplay(){

		Debug.Log ("yes");

	}



}
