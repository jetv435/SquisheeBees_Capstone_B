using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MG1LoseScript : MonoBehaviour {

	//How many times the player is allowed to mess up when their friend is on the screen.
	public int messUpsAllowed = 10;

	//Set up the string for the lose statement
	public string gameOverDialogue = "Please change this to appropiate dialogue!!";

	//Grabs the player and SRenderer so it can fade.
	GameObject playerObject;
	SpriteRenderer playerSprite;

	public float enlargingVariable = 1.5f;

	//Public Text grabber
	public UnityEngine.UI.Text textController;

	bool gameOverBool = false;

	// Use this for initialization
	void Start () {

		playerObject = GameObject.FindGameObjectWithTag ("Player");
		playerSprite = playerObject.GetComponent<SpriteRenderer>();

		textController.text = gameOverDialogue;
		textController.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Drops down the timer to lose the game.
	public void LoseCountdownFunction()
	{
		messUpsAllowed -= 1;


		if (messUpsAllowed <= 0) {
			textController.enabled = true;
			gameOverBool = true;
			Invoke ("GameOverReset", 3);
		}
	}

	public void SpriteEnlarge()
	{
		playerObject.transform.localScale *= enlargingVariable;


	}

	bool ReturnGameOverBool()
	{
		return gameOverBool;
	}

	void GameOverReset()
	{
		Scene sceneName = SceneManager.GetActiveScene();

		SceneManager.LoadScene (sceneName.name);
	}
}
