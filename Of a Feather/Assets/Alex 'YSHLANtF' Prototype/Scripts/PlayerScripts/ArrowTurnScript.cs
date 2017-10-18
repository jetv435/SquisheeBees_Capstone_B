using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTurnScript : MonoBehaviour {

	SpriteRenderer ownRender;

	// Use this for initialization
	void Start () {

		ownRender = gameObject.GetComponent<SpriteRenderer> ();

		ownRender.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnArrow(int arrowTurn)
	{
		float turnDegree = 90;

		ownRender.enabled = true;

		turnDegree *= arrowTurn;

		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, turnDegree);

	}

	public void disableArrow()
	{
		ownRender.enabled = false;
	}
}
