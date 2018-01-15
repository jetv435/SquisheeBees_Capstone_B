using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A prototype. To fix later when we get MinigameManager_MG1 finished.

public class MG1_ClassMove : MonoBehaviour {

	//Grabs the main TwoDGameManager
	public GameObject managerObject;
	TwoDGameManager managerScript;

	//Grabs the spriteObject and script
	public GameObject spriteControllerObject;
	SpriteControllerSprite spriteControlObjectScript;

	//Grabs the player
	public GameObject playerObject;

	//A public variable that we can change to mess with how far one goes.
	public float moveAwayDistance = 0.3f;

	// Use this for initialization
	void Start () {

		managerScript = managerObject.GetComponent<TwoDGameManager> ();
		spriteControlObjectScript = spriteControllerObject.GetComponent<SpriteControllerSprite> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow) ||
		    Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			if (managerScript.Get_friendSprOn() == false) {

				gameClassMoveFunction ();

			}
		}
		
	}

	void gameClassMoveFunction()
	{
		List<GameObject> gameClassList = spriteControlObjectScript.getListGameClass ();

		if (managerScript.Get_friendSprOn() == false) {

			Debug.Log ("Workin'");
								
			for (int i = 0; i < gameClassList.Count; i++) {
				Vector3 newPosition = gameClassList [i].transform.position;
				float distance = playerObject.transform.position.x + gameClassList [i].transform.position.x;

				if (distance > 0) {
					newPosition.x += moveAwayDistance;
				} 
				else {
					newPosition.x -= moveAwayDistance;
				}

				gameClassList [i].transform.position = newPosition;
			}
		}
	}
}
