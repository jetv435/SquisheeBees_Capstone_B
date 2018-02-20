using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3and4_MovementScript : MonoBehaviour {

	//Different Enums for the playerCharacter's movement
	public enum PLAYER_MOVEMENT{

		UP_PLAYER,
		DOWN_PLAYER,
		LEFT_PLAYER,
		RIGHT_PLAYER,
		NO_INPUT,
	}

	//Things that allow the keys to be pressed.
	bool allowUp = false;
	bool allowRight = false;
	bool allowLeft = false;


	public float playerMovement = 1.0f;
	//This is the grab the background size. To prevent the player from moving away.
	public GameObject backgroundObject;
	bool canMove = true;

	public bool isMinigameFour = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		//Correction_Passive ();

		if(Input.anyKey == true && canMove == true)
			Move_Generic ();
		if (Input.anyKey == false)
			canMove = true;
		
	}

	void FixedUpdate()
	{

	}


	//A simple code that allows for movement
	void Move_Generic()
	{
		if(isMinigameFour == false)
			canMove = false;

		PLAYER_MOVEMENT playerMoveVar = InputSet ();

		if (playerMoveVar == PLAYER_MOVEMENT.NO_INPUT) {

		}
		//Trying to cut back on code. This should save a line or two. Maybe. Both
		else if (playerMoveVar == PLAYER_MOVEMENT.UP_PLAYER || playerMoveVar == PLAYER_MOVEMENT.DOWN_PLAYER) {
			Move_Translation (new Vector3 (0, 1, 0), playerMoveVar);
		} else if (playerMoveVar == PLAYER_MOVEMENT.LEFT_PLAYER || playerMoveVar == PLAYER_MOVEMENT.RIGHT_PLAYER) {

			Move_Translation (new Vector3 (1, 0, 0), playerMoveVar);
		}

	}

	//Gets what key the player pressed.
	PLAYER_MOVEMENT InputSet()
	{

		if (Input.GetKey (KeyCode.UpArrow) && allowUp)
			return PLAYER_MOVEMENT.UP_PLAYER;
		else if (Input.GetKey (KeyCode.DownArrow))
			return PLAYER_MOVEMENT.DOWN_PLAYER;
		else if (Input.GetKey (KeyCode.LeftArrow) && allowLeft)
			return PLAYER_MOVEMENT.LEFT_PLAYER;
		else if (Input.GetKey (KeyCode.RightArrow) && allowRight)
			return PLAYER_MOVEMENT.RIGHT_PLAYER;

		return PLAYER_MOVEMENT.NO_INPUT;
	}

	void Move_Translation(Vector3 movementVar, PLAYER_MOVEMENT keyCheck_forMovement)
	{
		Vector3 newTranslation;

		//If the keycode is left or down, the vector gets flipped.
		if (keyCheck_forMovement == PLAYER_MOVEMENT.LEFT_PLAYER || keyCheck_forMovement == PLAYER_MOVEMENT.DOWN_PLAYER) {
			newTranslation = movementVar * -1 * playerMovement * .1f;
		} else {
			newTranslation = movementVar * playerMovement* .1f;
		}

		transform.position += newTranslation;

	}

	/*void OnCollisionStay2D(Collision2D other)
	{
		
		BoxCollider2D sizeOfHitBox = other.gameObject.GetComponent<BoxCollider2D> ();

		Debug.Log ("Bump");

		//If our x is where the other hit box is...
		if (transform.position.x >= other.transform.position.x - sizeOfHitBox.size.x /2 && 
			transform.position.x <= other.transform.position.x + sizeOfHitBox.size.x /2) {

			//If our object is lower than the other...
			if (transform.position.y < other.transform.position.y) {
				Vector2 newTranslation = transform.position;
				newTranslation.y -= playerMovement;
				transform.position = newTranslation;
			}
			//If the player object is higher than the other
			else if(transform.position.y > other.transform.position.y){
				Vector2 newTranslation = transform.position;
				newTranslation.y -= playerMovement/2;
				transform.position = newTranslation;
			}

			Correction_Passive ();
		}
		//If our y is where the other hit box is...
		else if (transform.position.y >= other.transform.position.y - sizeOfHitBox.size.y /2 && 
			transform.position.y <= other.transform.position.y + sizeOfHitBox.size.y /2) {

			//If our object is lefter than the other...
			if (transform.position.x < other.transform.position.x) {
				Vector2 newTranslation = transform.position;
				newTranslation.x -= playerMovement;
				transform.position = newTranslation;
			}
			//If the player object is righter than the other
			else if(transform.position.x > other.transform.position.x){
				Vector2 newTranslation = transform.position;
				newTranslation.x -= playerMovement;
				transform.position = newTranslation;
			}

			Correction_Passive ();
		}

		Correction_Passive ();

	}*/





	void Correction_Passive()
	{
		if (transform.position.y % playerMovement != 0) {
			Vector3 correction = transform.position;


			if (correction.y >= playerMovement / 2) {
				float difference = 1 - (correction.y % playerMovement);

				correction.y += difference;
			} else if (correction.y < playerMovement / 2) {
				float difference = correction.y % playerMovement;

				correction.y -= difference;
			}

			transform.position = correction;
		}
		if (transform.position.x % playerMovement != 0) {
			Debug.Log ("X is wrong");
			Vector3 correction = transform.position;

			if (correction.x >= playerMovement / 2) {
				float difference = 1 - (correction.x % playerMovement);

				correction.x += difference;
			} else if (correction.x < playerMovement / 2) {
				float difference = correction.x % playerMovement;

				correction.x -= difference;
			}

			transform.position = correction;
		}


	}

	public void ActivateKey(string keyToActivate)
	{
		if (keyToActivate == "Right") {
			allowRight = true;
		} else if (keyToActivate == "Left") {
			allowLeft = true;
		} else if (keyToActivate == "Up") {
			allowUp = true;
		}
	}


}
