using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ARROW_TYPE
{
	CLASS,
	FRIEND,
	SELF
}

public class ArrowTurnScript : MonoBehaviour 

, IRhythmFeedbackListener
, IRhythmPromptListener
{

	SpriteRenderer ownRender;
	GameObject TwoDGameManObj;
	TwoDGameManager TwoDGameManScr;

	//Change Sprite
	GameObject callSpriteBoss;
	SpriteControllerSprite callSprScr;

	//Use this to distinguish which type of arrow it is.
	public ARROW_TYPE arrowTag;

	//So we can store arrowTurn
	int arrowNumber;


	// Use this for initialization
	void Start () {

		TwoDGameManObj = GameObject.FindGameObjectWithTag ("GameControl2D");
		TwoDGameManScr = TwoDGameManObj.GetComponent<TwoDGameManager> ();

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		ownRender = gameObject.GetComponent<SpriteRenderer> ();

		ownRender.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnArrow(int arrowTurn)
	{
		float turnDegree = 90;
		if (arrowTag == ARROW_TYPE.CLASS)
			ownRender.enabled = true;
		else if (arrowTag == ARROW_TYPE.FRIEND && TwoDGameManScr.GetLevelName() == TwoDGameManager.LEVEL_2D_NAMES.STAGE_1 ) {
			if (TwoDGameManScr.SetArrowOn () == true) {
				ownRender.enabled = true;
			}
		}

		turnDegree *= arrowTurn;

		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, turnDegree);

		//Sends the manager the current number, which will be used later, as well as the enum tag of the arrow.
		TwoDGameManScr.ChangeArrowNumber(arrowTurn, arrowTag);
		arrowNumber = arrowTurn;

	}

	public void disableArrow()
	{
		ownRender.enabled = false;
	}


	public void HitNotify()
	{
		// Do something when user hits correct input
		//Debug.Log("Hit");

		TwoDGameManScr.IncreaseScore (arrowTag);
		callSprScr.masterPlayerSpriteChange (arrowNumber, arrowTag);
		if (arrowTag == ARROW_TYPE.CLASS) {
			TwoDGameManScr.SendSoundToPlayAtSoundScript (0);
		}
		else if (arrowTag == ARROW_TYPE.FRIEND) {
			TwoDGameManScr.SendSoundToPlayAtSoundScript (1);
		}

	}

	public void MissNotify()
	{
		// Do something when user hits incorrect input
		//Debug.Log("Miss");
		TwoDGameManScr.SendSoundToPlayAtSoundScript (0);

	}

	public void TimeoutNotify()
	{
		// Do something when beat times out
		//Debug.Log("Timeout");
		TwoDGameManScr.SendSoundToPlayAtSoundScript (0);

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
				TurnArrow (1);
				break;
			}

		case KeyCode.DownArrow:
			{
				TurnArrow (2);
				break;
			}
		case KeyCode.RightArrow:
			{
				TurnArrow (3);
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
