using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDGameManager : MonoBehaviour {

	int Score = 0;
	public int maxScoreFriend = 3;
	public int maxScoreNeededInTotal = 10;
	bool friendSprOn = false;

	//Change Sprite
	GameObject callSpriteBoss;
	SpriteControllerSprite callSprScr;

	//Change scenes
	GameObject sceneBoss;
	GameBossCode sceneControl;

	//To manage the arrow scripts
	public GameObject arrowObj;
	ArrowTurnScript arrowScr;
	public GameObject arrowObjFriend;
	ArrowTurnScript arrowScrFrd;

	//A bool to send to SpawnMaster.
	bool ArrowOn = false;


	//This code calls on the friend's mark, allowing it to be sent to the TwoMainCode later.
	//SpawnerMaster gives the friends number.
	int friendMark = -1;

	// Use this for initialization
	void Start () {

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		sceneBoss = GameObject.FindGameObjectWithTag ("GameController");
		sceneControl = sceneBoss.GetComponent<GameBossCode> ();

		arrowScr = arrowObj.GetComponent<ArrowTurnScript>();
		arrowScrFrd = arrowObjFriend.GetComponent<ArrowTurnScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Score >= maxScoreFriend && friendSprOn == false) {
			callSprScr.TurnOnFriendSpr ();
			ArrowOn = true;
			friendSprOn = true;
		}

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
		arrowScrFrd.disableArrow ();
	}
}
