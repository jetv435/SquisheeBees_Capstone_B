using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class importTex : MonoBehaviour {


	/* This script is to import the files we have. I suggest we seperate each dialogue by basement to make it easier to 
	 * parse through and the numbers don't go so high */
	public TextAsset textfile;
	public string[] dialoglines;



	// Use this for initialization
	void Start () {

		if (textfile != null) {

			dialoglines = (textfile.text.Split ('\n'));
		}
		
	}
}
