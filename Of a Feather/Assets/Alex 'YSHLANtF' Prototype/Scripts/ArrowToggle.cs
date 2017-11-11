using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ArrowToggle : MonoBehaviour {

	public bool notesOn = false;
	public GameObject upArrow;
	public GameObject leftArrow;
	public GameObject downArrow;
	public GameObject rightArrow;

	// Use this for initialization
	void Start () {

		if (notesOn == false) {
			
			SetUpArrowsRadial ();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetUpArrowsRadial()
	{
		upArrow.transform.position = new Vector2 (0, 2);
		leftArrow.transform.position = new Vector2 (-2, 0);
		downArrow.transform.position = new Vector2 (0, -2);
		rightArrow.transform.position = new Vector2 (2, 0);
	}

	public bool returnToggle()
	{
		return notesOn;
	}
}
