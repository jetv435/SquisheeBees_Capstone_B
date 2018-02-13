using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class dialogReader : MonoBehaviour {

	/* attached to every object that can be picked up and has a description attached to it
	 * if it's not attached, the code will null, but not crash the game */

	public TextAsset dialog;

	public int startline;
	public int endline;

	public DialogManager DM;

	void Start () {
		DM = FindObjectOfType<DialogManager> ();

	}


	 /* important function: this gets read in the PickupPlayerScript.
	  * It serves to communicate to the script that if a raycast has been hit
	  * and collided with an object, it will recognize that the object might 
	  * have a description. If it does, it will call this function.
	  * */
	public void readlines(){
		DM.reloadscript (dialog);
		DM.currentline = startline;
		DM.activateTxtBox ();

	}

}