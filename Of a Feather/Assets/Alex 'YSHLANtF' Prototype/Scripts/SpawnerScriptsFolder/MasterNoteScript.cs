using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterNoteScript : MonoBehaviour {

	bool keepOnGoing = true;
	Vector2 oriPos;
	//Gets the main 2D controller
	GameObject gamBosObj;
	TwoDGameManager gameBosScr;



	// Use this for initialization
	void Start () {
		oriPos = transform.position;

		gamBosObj = GameObject.FindGameObjectWithTag ("GameControl2D");
		gameBosScr = gamBosObj.GetComponent<TwoDGameManager> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//If it collides, it sets the master note back into original pos.
	void OnCollisionEnter2D(Collision2D other)
	{
		//Also increases score and hides the arrows
		if (other.gameObject.tag == "Player") {
			transform.position = oriPos;
			gameBosScr.IncreaseScore (1);

		}
	}

	//Gives information on the bool "keepOnGoing". It is used as a master variable to SpawnerMasterScript
	public bool giveGoing()
	{

		return keepOnGoing;

	}

	//A void that makes the bool false. 
	public void stopGoing()
	{
		keepOnGoing = false;

	}
}
