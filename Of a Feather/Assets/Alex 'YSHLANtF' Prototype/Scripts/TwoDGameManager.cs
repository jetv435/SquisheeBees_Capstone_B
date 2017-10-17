using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDGameManager : MonoBehaviour {

	int Score = 0;
	public int maxScoreFriend = 3;
	bool friendSprOn = false;

	//Change Sprite
	GameObject callSpriteBoss;
	SpriteControllerSprite callSprScr;

	// Use this for initialization
	void Start () {

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Score >= maxScoreFriend && friendSprOn == false) {
			callSprScr.TurnOnFriendSpr ();
		}
		
	}

	public void IncreaseScore()
	{
		Score++;
	}
}
