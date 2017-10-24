using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDMainCode : MonoBehaviour {

	public GameObject upObj;
	SpriteRenderer upSprite;
	BoxCollider2D upCollider;

	public GameObject downObj;
	SpriteRenderer downSprite;
	BoxCollider2D downCollider;

	public GameObject leftObj;
	SpriteRenderer leftSprite;
	BoxCollider2D leftCollider;

	public GameObject rightObj;
	SpriteRenderer rightSprite;
	BoxCollider2D rightCollider;

	//Calls the main sprite script to change sprites
	GameObject callSpriteBoss;
	SpriteControllerSprite callSprScr;

	//Calls the controller of the 2D scenes
	GameObject gamBosObj;
	TwoDGameManager gameBosScr;



	// Use this for initialization
	void Start () {

		upSprite = upObj.GetComponent<SpriteRenderer> ();
		upCollider = upObj.GetComponent<BoxCollider2D> ();
		downSprite = downObj.GetComponent<SpriteRenderer> ();
		downCollider = downObj.GetComponent<BoxCollider2D> ();
		leftSprite = leftObj.GetComponent<SpriteRenderer> ();
		leftCollider = leftObj.GetComponent<BoxCollider2D> ();
		rightSprite = rightObj.GetComponent<SpriteRenderer> ();
		rightCollider = rightObj.GetComponent<BoxCollider2D> ();

		upCollider.enabled = false;
		downCollider.enabled = false;
		leftCollider.enabled = false;
		rightCollider.enabled = false;

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		gamBosObj = GameObject.FindGameObjectWithTag ("GameControl2D");
		gameBosScr = gamBosObj.GetComponent<TwoDGameManager> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		InputControlArrows ();
		
	}

	void InputControlArrows()
	{
		//Uparrow
		if (Input.GetKeyDown (KeyCode.UpArrow) == true) {
			upSprite.color = Color.red;
			upCollider.enabled = true;
			SpriteChangerFunc (0);
		} else if(Input.GetKey (KeyCode.UpArrow) == false){
			upSprite.color = Color.white;
			upCollider.enabled = false;

		}

		//Downarrow
		if (Input.GetKeyDown (KeyCode.DownArrow) == true) {
			downSprite.color = Color.red;
			downCollider.enabled = true;
			SpriteChangerFunc (2);
		} else if(Input.GetKey (KeyCode.DownArrow) == false){
			downSprite.color = Color.white;
			downCollider.enabled = false;
		}

		//leftarrow
		if (Input.GetKeyDown (KeyCode.LeftArrow) == true) {
			leftSprite.color = Color.red;
			leftCollider.enabled = true;
			SpriteChangerFunc (1);
		} else if(Input.GetKey (KeyCode.LeftArrow) == false){
			leftSprite.color = Color.white;
			leftCollider.enabled = false;
		}

		//Rightarrow
		if (Input.GetKeyDown (KeyCode.RightArrow) == true) {
			rightSprite.color = Color.red;
			rightCollider.enabled = true;
			SpriteChangerFunc (3);
		} else if(Input.GetKey (KeyCode.RightArrow) == false){
			rightSprite.color = Color.white;
			rightCollider.enabled = false;
		}
	}

	//A function to clean up a little bit
	void SpriteChangerFunc(int sendListMark)
	{
		//If friend's number and PC's number match, instantly change
		if (gameBosScr.SendFriendsNumber() == sendListMark) {
			callSprScr.PlayerInstantChange (sendListMark);
			gameBosScr.IncreaseScore (2);
		}
		//Or else delay
		else {
			callSprScr.PlayerChange (sendListMark);
		}
	}
		


}
