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
	bool bFriendArrowEnabled = false;

	//Previous calls from the arrows
    int classPosePrev = 0;
	int friendPosePrev = -1;


	//Calls the Rhythm Script, if it is on level 2. The Rhythm Script is tagged as "RhythmTag"
	//The two variables, one to get the object. The other gets the RhythmCore script.
	GameObject rhyGObj;
	RhythmCore rhyScr;


	//This code calls on the friend's mark, allowing it to be sent to the TwoMainCode later.
	//SpawnerMaster gives the friends number.
    int friendCurrSpriteIndex = -1;

	//To determine what level it is.
	public LEVEL_2D_NAMES nameOfLevel;

	private MainMenuManager MM;

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
		MM = GameObject.FindGameObjectWithTag ("MManager").GetComponent<MainMenuManager> ();

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
				callSprScr.EnableFriendSprite ();
				bFriendArrowEnabled = true;
				friendSprOn = true;
				friendenter.Play ();
			}
		}

		//Need to change it later, once we get animations
		if (Score >= maxScoreNeededInTotal) {
			sceneControl.GoToBasement (1);
		}


		
	}

	public bool IsFriendArrowEnabled()
	{
        return bFriendArrowEnabled;
	}

	//Gets the arrow number from the SpawnerMaster also changes friend's sprite.
    public void setFriendSpriteIndex(int index)
	{
		friendCurrSpriteIndex = index;
		callSprScr.FriendChange (friendCurrSpriteIndex);

	}

	//Sends the friend's number
	public int getFriendCurrSpriteIndex()
	{
		return friendCurrSpriteIndex;
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

				//Due to the fact that this implicitly implies it is stage one,
				//It calls the particle effect.
				callSprScr.ActivateParticleEffect();
			}
		}
		arrowScr.disableArrow ();
		if(nameOfLevel == LEVEL_2D_NAMES.STAGE_1)
			arrowScrFrd.disableArrow ();
	}

	//A call from the arrow script to give the angle of the arrow.
	//Can be reused with the ARROW_TYPE enum, with it also changing the friend arrow previous arrow.
	public void ChangeArrowNumber(int change, ARROW_TYPE arrowClass)
	{
		if (arrowClass == ARROW_TYPE.FRIEND) {
			friendPosePrev = change;
			callSprScr.FriendChange (friendPosePrev);
		}
		else if (arrowClass == ARROW_TYPE.CLASS) {
			classPosePrev = change;
			callSprScr.ClassChange (classPosePrev);
		} 
	}

	//Gives the randomizer code in Rhythmcore the previous number of the class
    public KeyCode getClassPosePrevKey()
	{
		if (classPosePrev == 0)
			return KeyCode.UpArrow;
		else if (classPosePrev == 1)
			return KeyCode.LeftArrow;
		else if (classPosePrev == 2)
			return KeyCode.DownArrow;
		else if (classPosePrev == 3)
			return KeyCode.RightArrow;

		return KeyCode.A;
	}

    public void PlayCorrectSound()
    {
        Debug.Log("Playing Correct Sound...");
        soundScr.PlayCorrect();
    }

    public void PlayWrongSound()
    {
        Debug.Log("Playing Wrong Sound...");
        soundScr.PlayWrong();
    }

	//Gives the level's name
	public LEVEL_2D_NAMES GetLevelName()
	{
		return nameOfLevel;
	}
}
