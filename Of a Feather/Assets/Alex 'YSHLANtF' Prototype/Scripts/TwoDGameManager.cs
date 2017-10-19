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

	GameObject sceneBoss;
	GameBossCode sceneControl;

	// Use this for initialization
	void Start () {

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		sceneBoss = GameObject.FindGameObjectWithTag ("GameController");
		sceneControl = sceneBoss.GetComponent<GameBossCode> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Score >= maxScoreFriend && friendSprOn == false) {
			callSprScr.TurnOnFriendSpr ();
		}

		if (Score >= maxScoreNeededInTotal) {
			sceneControl.GoToBasement (1);
		}
		
	}

	public void IncreaseScore()
	{
		Score++;
	}
}
