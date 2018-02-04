using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1LoseScript : MonoBehaviour {

	//How many times the player is allowed to mess up when their friend is on the screen.
	public int messUpsAllowed = 10;

	//Set up the string for the lose statement
	public string gameOverDialogue = "Please change this to appropiate dialogue!!";

	//Grabs the player and SRenderer so it can fade.
	GameObject playerObject;
	SpriteRenderer playerSprite;

	float faderVariable;

	//Public Text grabber
	public UnityEngine.UI.Text textController;

	// Use this for initialization
	void Start () {

		playerObject = GameObject.FindGameObjectWithTag ("Player");
		playerSprite = playerObject.GetComponent<SpriteRenderer>();

		textController.text = gameOverDialogue;
		textController.enabled = false;

		faderVariable = 1 / messUpsAllowed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Drops down the timer to lose the game.
	public void LoseCountdownFunction()
	{
		messUpsAllowed -= 1;
		SpriteFade ();

		if (messUpsAllowed <= 0) {
			textController.enabled = true;
		}
	}

	void SpriteFade()
	{

		playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, playerSprite.color.a - faderVariable);

	}
}
