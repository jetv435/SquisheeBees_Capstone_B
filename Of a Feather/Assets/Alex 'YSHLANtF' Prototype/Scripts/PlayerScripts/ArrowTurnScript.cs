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
    MGDirectionUtils.MGDirection arrowDirection = MGDirectionUtils.MGDirection.UNSET;

	// Use this for initialization
	void Start ()
    {

		TwoDGameManObj = GameObject.FindGameObjectWithTag ("GameControl2D");
		TwoDGameManScr = TwoDGameManObj.GetComponent<TwoDGameManager> ();

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		ownRender = gameObject.GetComponent<SpriteRenderer> ();

		ownRender.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {}

    static public float DirectionToArrowAngle(MGDirectionUtils.MGDirection dir)
    {
        float ret = 0.0f;
        switch(dir)
        {
            case MGDirectionUtils.MGDirection.UP:
                {
                    ret = 0.0f;
                } break;
            case MGDirectionUtils.MGDirection.DOWN:
                {
                    ret = 180.0f;
                } break;
            case MGDirectionUtils.MGDirection.LEFT:
                {
                    ret = 90.0f;
                } break;
            case MGDirectionUtils.MGDirection.RIGHT:
                {
                    ret = 270.0f;
                } break;
            default:
                {
                    Debug.LogError("Invalid value for 'dir' in ArrowTurnScript.ConvertDirectionToArrowAngle()");
                } break;
        }
        return ret;
    }

    public void TurnArrow(MGDirectionUtils.MGDirection direction)
    {
        if (arrowTag == ARROW_TYPE.CLASS)
            ownRender.enabled = true;
        else if (arrowTag == ARROW_TYPE.FRIEND && TwoDGameManScr.GetLevelName() == TwoDGameManager.LEVEL_2D_NAMES.STAGE_1)
        {
            if (TwoDGameManScr.IsFriendArrowEnabled() == true)
            {
                ownRender.enabled = true;
            }
        }

        // Determine the arrow's angle for the given direction
        float turnDegree = DirectionToArrowAngle(direction);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, turnDegree);
        //Sends the manager the current number, which will be used later, as well as the enum tag of the arrow.
        TwoDGameManScr.ChangeCharacterPose(direction, arrowTag);
        arrowDirection = direction;
    }

	public void disableArrow()
	{
		ownRender.enabled = false;
	}


	public void HitNotify()
	{
		// Do something when user hits correct input

		TwoDGameManScr.IncreaseScore (arrowTag);
        callSprScr.setPlayerSpritePose (arrowDirection, arrowTag);
		if (arrowTag == ARROW_TYPE.CLASS)
        {
            TwoDGameManScr.PlayWrongSound();
		}
		else if (arrowTag == ARROW_TYPE.FRIEND)
        {
            TwoDGameManScr.PlayCorrectSound();
		}
	}

	public void MissNotify()
	{
		// Do something when user hits incorrect input
        TwoDGameManScr.PlayWrongSound();
	}

	public void TimeoutNotify()
	{
        // Do something when beat times out
        TwoDGameManScr.PlayWrongSound();

		//If the stage is 2, then it also counts for the score, to make it faster and faster.
		//Uses all of the game Manager's scripts
		if (TwoDGameManScr.GetLevelName () == TwoDGameManager.LEVEL_2D_NAMES.STAGE_2)
        {
			TwoDGameManScr.IncreaseScore (arrowTag);
		}
	}

	public void PromptNotify(RhythmCore.RhythmExpectedEventInfo eventInfo)
	{
        // Do something when a beat is queued up (we enter a beat window)
        //Debug.Log("Prompt");
        TurnArrow(MGDirectionUtils.DirectionFromKey(eventInfo.expectedKey));
	}
}
