using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterNoteScript : MonoBehaviour {

	bool keepOnGoing = true;
	Vector2 oriPos;
	GameObject gamBosObj;
	TwoDGameManager gameBosScr;

	public GameObject arrowObj;
	ArrowTurnScript arrowScr;

	// Use this for initialization
	void Start () {
		oriPos = transform.position;

		gamBosObj = GameObject.FindGameObjectWithTag ("GameControl2D");
		gameBosScr = gamBosObj.GetComponent<TwoDGameManager> ();

		arrowScr = arrowObj.GetComponent<ArrowTurnScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			transform.position = oriPos;
			gameBosScr.IncreaseScore ();
			arrowScr.disableArrow ();
		}
	}

	public bool giveGoing()
	{

		return keepOnGoing;

	}
	public void stopGoing()
	{
		keepOnGoing = false;

	}
}
