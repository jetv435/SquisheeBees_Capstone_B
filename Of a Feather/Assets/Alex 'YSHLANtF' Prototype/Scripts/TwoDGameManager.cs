using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDGameManager : MonoBehaviour {

	//So we can keep the base code with some levels, as well as have some
	//new stuff leading to the next.
	public enum LEVEL_2D_NAMES
	{
		STAGE_1,
		STAGE_2,
		STAGE_3,
		STAGE_4,
	}



	int Score = 0;
	public int maxScoreFriend = 3;
	public int maxScoreNeededInTotal = 10;
	bool friendSprOn = false;
	public AudioSource friendenter;

	//Change Sprite
	GameObject callSpriteBoss;
	SpriteControllerSprite callSprScr;

	//Change scenes
	GameObject sceneBoss;
	GameBossCode sceneControl;

	//Calls Sound script
	GameObject soundObj;
	SoundScript soundScr;

	//To manage the arrow scripts
	public GameObject arrowObj;
	ArrowTurnScript arrowScr;
	public GameObject arrowObjFriend;
	ArrowTurnScript arrowScrFrd;

	//A bool to send to SpawnMaster.
	bool ArrowOn = false;

	//Previous calls from the arrows
	int classArrNumPrev = 0;
	int friendArrNumPrev = -1;


	//Calls the Rhythm Script, if it is on level 2. The Rhythm Script is tagged as "RhythmTag"
	//The two variables, one to get the object. The other gets the RhythmCore script.
	GameObject rhyGObj;
	RhythmCore rhyScr;


	//This code calls on the friend's mark, allowing it to be sent to the TwoMainCode later.
	//SpawnerMaster gives the friends number.
	int friendMark = -1;

	//To determine what level it is.
	public LEVEL_2D_NAMES nameOfLevel;

	// Use this for initialization
	void Start () {

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		sceneBoss = GameObject.FindGameObjectWithTag ("GameController");
		sceneControl = sceneBoss.GetComponent<GameBossCode> ();

		soundObj = GameObject.FindGameObjectWithTag ("SoundControllerTag");
		soundScr = soundObj.GetComponent<SoundScript> ();

		arrowScr = arrowObj.GetComponent<ArrowTurnScript>();
		//If it isn't level 2 or 3, get the arrow's script of the friend.
		if (nameOfLevel != LEVEL_2D_NAMES.STAGE_2 || nameOfLevel != LEVEL_2D_NAMES.STAGE_3) {
			arrowScrFrd = arrowObjFriend.GetComponent<ArrowTurnScript> ();
		}

		//If the enum of nameOfLevel is STAGE_2, then it sets the rhythm object.
		if (nameOfLevel == LEVEL_2D_NAMES.STAGE_2) {
			rhyGObj = GameObject.FindGameObjectWithTag ("RhythmTag");
			rhyScr = rhyGObj.GetComponent<RhythmCore>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (nameOfLevel == LEVEL_2D_NAMES.STAGE_1) {
			if (Score >= maxScoreFriend && friendSprOn == false) {
				callSprScr.TurnOnFriendSpr ();
				ArrowOn = true;
				friendSprOn = true;
				friendenter.Play ();
			}
		}

		//Need to change it later, once we get animations
		if (Score >= maxScoreNeededInTotal) {
			sceneControl.GoToBasement (1);
		}


		
	}

	public bool SetArrowOn()
	{
		return ArrowOn;
	}

	//Gets the arrow number from the SpawnerMaster also changes friend's sprite.
	public void SetFriendsNumber(int setMark)
	{
		friendMark = setMark;
		callSprScr.FriendChange (friendMark);

	}

	//Sends the friend's number
	public int SendFriendsNumber()
	{
		return friendMark;
	}

	//Changes "score" as well as disables the arrows
	public void IncreaseScore(int scoreIncrease)
	{

		if (friendSprOn == false) {
			Score += scoreIncrease;
		} else {
			if (scoreIncrease == 2) {
				scoreIncrease = 1;
				Score += scoreIncrease;
			}
		}
		arrowScr.disableArrow ();
		if(nameOfLevel == LEVEL_2D_NAMES.STAGE_1)
			arrowScrFrd.disableArrow ();
	}

	//New score func that checks on the arrow type now
	public void IncreaseScore(ARROW_TYPE arrowEnum)
	{

		if (friendSprOn == false) {
			Score++;
		} else {
			if(arrowEnum == ARROW_TYPE.FRIEND)
			{
				Score++;
			}
		}
		arrowScr.disableArrow ();
		if(nameOfLevel == LEVEL_2D_NAMES.STAGE_1)
			arrowScrFrd.disableArrow ();

		if (nameOfLevel == LEVEL_2D_NAMES.STAGE_2) {
			rhyScr.beatWindowDuration--;
		}
	}

	//A call from the arrow script to give the angle of the arrow.
	//Can be reused with the ARROW_TYPE enum, with it also changing the friend arrow previous arrow.
	public void ChangeArrowNumber(int change, ARROW_TYPE arrowClass)
	{
		if (arrowClass == ARROW_TYPE.FRIEND) {
			friendArrNumPrev = change;
			callSprScr.FriendChange (friendArrNumPrev);
			soundScr.ResumePlay ();
		}
		else if (arrowClass == ARROW_TYPE.CLASS) {
			classArrNumPrev = change;
			callSprScr.ClassChange (classArrNumPrev);
			soundScr.ResumePlay ();
		} 
	}

	//Gives the randomizer code in Rhythmcore the previous number of the class
	public KeyCode GivePrevClassNum()
	{
		if (classArrNumPrev == 0)
			return KeyCode.UpArrow;
		else if (classArrNumPrev == 1)
			return KeyCode.LeftArrow;
		else if (classArrNumPrev == 2)
			return KeyCode.DownArrow;
		else if (classArrNumPrev == 3)
			return KeyCode.RightArrow;

		return KeyCode.A;
	}

	//Gets the sound and plays it. Mainly for the correct and incorrect notes.
	public void SendSoundToPlayAtSoundScript(int binaryRightWrong)
	{
		//Wrong
		if (binaryRightWrong == 0) {
			soundScr.PlayWrong ();
		}
		//right
		else {
			soundScr.PlayCorrect ();
		}
	}


	//Gives the level's name
	public LEVEL_2D_NAMES GetLevelName()
	{
		return nameOfLevel;
	}
}
