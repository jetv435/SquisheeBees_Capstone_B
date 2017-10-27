using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTurnScript : MonoBehaviour {

	SpriteRenderer ownRender;
	GameObject TwoDGameManObj;
	TwoDGameManager TwoDGameManScr;


	// Use this for initialization
	void Start () {

		TwoDGameManObj = GameObject.FindGameObjectWithTag ("GameControl2D");
		TwoDGameManScr = TwoDGameManObj.GetComponent<TwoDGameManager> ();

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


	public void HitNotify()
	{
		// Do something when user hits correct input
		//Debug.Log("Hit");

		TwoDGameManScr.IncreaseScore (2);

	}

	public void MissNotify()
	{
		// Do something when user hits incorrect input
		//Debug.Log("Miss");
		;
	}

	public void TimeoutNotify()
	{
		// Do something when beat times out
		//Debug.Log("Timeout");

	}

	public void PromptNotify(RhythmCore.RhythmExpectedEventInfo eventInfo)
	{
		// Do something when a beat is queued up (we enter a beat window)
		//Debug.Log("Prompt");

		switch (eventInfo.expectedKey) {

		case KeyCode.UpArrow:
			{
				TurnArrow (0);
				break;
			}
		case KeyCode.LeftArrow:
			{
				TurnArrow (3);
				break;
			}

		case KeyCode.DownArrow:
			{
				TurnArrow (2);
				break;
			}
		case KeyCode.RightArrow:
			{
				TurnArrow (1);
				break;
			}
		default:
			{
				Debug.LogError("Unexpected eventInfo.expectedKey value in ArrowTurnScript.EventQueuedNotify");
				break;
			}


		}


	}
}
