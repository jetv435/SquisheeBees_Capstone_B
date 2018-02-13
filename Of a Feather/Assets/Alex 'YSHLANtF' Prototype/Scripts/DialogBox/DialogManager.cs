using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	/*assigned to one object per room. */

	public GameObject dialogbox;

	public Text textObj;

	public TextAsset dialog;

	public string [] dialoglines;

	public int currentline;

	public int endatline;

	public bool isactive;



	// Use this for initialization
	/* does a check to make sure there is a text file attached and if it does, 
	 * it splits the text by every new line.*/
	void Start () {

		if (dialog != null) {
			dialoglines = (dialog.text.Split ('\n'));

		}


		if (isactive) {
			activateTxtBox ();
		} else {
			deactivateTxtBox ();
		}


	}

	/* updates the list to match the currentline of dialog, based on the object you are holding.
	 * the conditional is only there as reference to make sure that the end of the document hasn't 
	 * been reached. */
	public void Update(){

		if (!isactive) {
			return;
		}

		textObj.text = dialoglines [currentline];
		if (endatline == 0) {
			endatline = dialoglines.Length - 1;
		}
	}

	public void activateTxtBox(){

		dialogbox.SetActive (true);
		isactive = true;


	}


	public void deactivateTxtBox(){

		dialogbox.SetActive (false);
		isactive = false;

	}

	/* This function works if we want to use a different text file for each object. */

	public void reloadscript(TextAsset text){

		if (text != null) {
			dialoglines = new string[1];
			dialoglines = (text.text.Split ('\n'));
		}

	}

}

