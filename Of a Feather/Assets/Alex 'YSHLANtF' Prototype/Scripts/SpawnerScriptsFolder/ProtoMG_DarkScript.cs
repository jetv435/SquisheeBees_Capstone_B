using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------------
//Protoype of the script for minigame 3: Dark
//Shall be cleaned up later. 
//--------------------------------------

public class ProtoMG_DarkScript : MonoBehaviour {

	//Just to grab the Spritecontroller in the scene. Could be cleaned up.
	public GameObject ProtoSpriteControllerObject;
	SpriteControllerSprite ProtoSpriteControllerScript;

	//Grabs the background to help it fade back to color.
	public GameObject BackgroundObject;
	SpriteRenderer BackgroundSpriteRenderer;

	//Grabs the 3D text in the scene. Just getting something out there.
	public GameObject TextObject;
	TextMesh TextTextMesh; //I know it's redudant. 

	//Something to make the playerCharacter at first resist the player inputs.
	bool resistanceToInputs = true;

	//Public String that we can use to have dialogue appear the character.
	//Will make another script and object if we have more than one saying
	public string defeatestSaying;

	//Just for the test arrow.
	public GameObject arrowObject;

	//How many times we want the player to struggle with the resistance until we hand them control.
	public int resistMaximum = 5;
	int resistVariable = 0;

	// Use this for initialization
	void Start () {


		ProtoSpriteControllerScript = ProtoSpriteControllerObject.GetComponent<SpriteControllerSprite> ();
		BackgroundSpriteRenderer = BackgroundObject.GetComponent<SpriteRenderer> ();
		TextTextMesh = TextObject.GetComponent<TextMesh> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		//Another gross protocode. Will Change later.
		//If resistancesToInputs is true, then the player character will not follow inputs.
		//If false, then they will.
		if (resistanceToInputs == true) {
			if (Input.anyKeyDown == true) {
				TextTextMesh.text = defeatestSaying;
				ResistanceKeyPress ();
			}
		} else {

			TextTextMesh.text = "Boy howdy, I can do it.";

			//ALEX: A gross, but simple way to test out minigame three. Shall change later after my crash course on coding.
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				UpdateArrowAndPlayerSprites (0);
				BackgroundFadeBackIn ();
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				UpdateArrowAndPlayerSprites (1);
				BackgroundFadeBackIn ();
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				UpdateArrowAndPlayerSprites (2);
				BackgroundFadeBackIn ();
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				UpdateArrowAndPlayerSprites (3);
				BackgroundFadeBackIn ();
			}
		}
		
	}
		


	//A code to disable ResistanceToInputs eventually. Also has a code incase we want something like wiggling to show struggling.
	void ResistanceKeyPress()
	{
		if (resistVariable >= resistMaximum) {
			resistanceToInputs = false;
		}

		resistVariable++;
	}

	//A simple code that both changes the player's sprite and changes the arrow direction.
	void UpdateArrowAndPlayerSprites(int newVar)
	{
		ProtoSpriteControllerScript.PlayerSpriteChangeMG3 (newVar);
		TurnArrow (newVar);
	}

	//This is the code we can use to slowly fade back in as the player continues within the minigame.
	//We can probably keep this in, even when cleaned up.
	void BackgroundFadeBackIn ()
	{
		Color deltaColor = BackgroundSpriteRenderer.color;
		float changeColorValues = .01f;
		deltaColor.r += changeColorValues;
		deltaColor.g += changeColorValues;
		deltaColor.b += changeColorValues;

		BackgroundSpriteRenderer.color = deltaColor;
	}

	//Lazily done turn code. WILL CHANGE
	public void TurnArrow(int arrowTurn)
	{
		float turnDegree = 90;


		turnDegree *= arrowTurn;

		arrowObject.transform.eulerAngles = new Vector3 (arrowObject.transform.eulerAngles.x, arrowObject.transform.eulerAngles.y, turnDegree);


	}
}
