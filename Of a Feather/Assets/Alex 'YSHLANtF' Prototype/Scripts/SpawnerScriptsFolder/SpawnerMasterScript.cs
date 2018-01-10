using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMasterScript : MonoBehaviour {

	public List<GameObject> spawnerList = new List<GameObject>();
	public float timerCoolDownSec = 1.0f; //Could be made redundant later.
	float timerCoolDownSecret;
	float mainTimer;

	public GameObject mainNote;
	public List<GameObject> playerArrowList = new List<GameObject>();

	//Change Sprite
	GameObject callSpriteBoss;
	SpriteControllerSprite callSprScr;

	//Lazy arrow call script
	public GameObject arrowObj;
	ArrowTurnScript arrowScr;
	//EquallyLazy other arrowcall script for friend
	public GameObject arrowObjFrnd;
	ArrowTurnScript arrowScrFrnd;

	//Calls the controller of the 2D scenes
	GameObject gamBosObj;
	TwoDGameManager gameBosScr;

	//To prevent repeats of the same direction of the arrows
    int prevClassPose = 2;
    int prevFriendPose = 1;

	//used to get the audio source, instead of requesting a public audiosource
	GameObject MCamera;
	AudioSource Maudio;




	// Use this for initialization
	void Start () {

		gamBosObj = GameObject.FindGameObjectWithTag ("GameControl2D");
		gameBosScr = gamBosObj.GetComponent<TwoDGameManager> ();

		timerCoolDownSecret = timerCoolDownSec;
		mainTimer = timerCoolDownSec;


		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		//Really lazy code work
		arrowScr = arrowObj.GetComponent<ArrowTurnScript>();
		arrowScrFrnd = arrowObjFrnd.GetComponent<ArrowTurnScript> ();

		//also lazy code copier right here
		MCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		Maudio = MCamera.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (mainTimer <= 0) {
			mainTimer = timerCoolDownSecret + Random.Range (3, 5);
			int randSpawner = Random.Range (0, playerArrowList.Count);
			int randFriend = Random.Range (0, playerArrowList.Count);
			Maudio.UnPause ();

			while (randSpawner == prevClassPose) {
				randSpawner = Random.Range (0, playerArrowList.Count);
			}
			while (randFriend == prevFriendPose || randFriend == randSpawner || randFriend == prevClassPose) {
				randFriend = Random.Range (0, playerArrowList.Count);
			}

			prevClassPose = randSpawner;
			prevFriendPose = randFriend;

			mainNote.transform.position = playerArrowList [randSpawner].transform.position;
			callSprScr.ClassChange (randSpawner);

			arrowScr.TurnArrow (randSpawner);
			if (gameBosScr.IsFriendArrowEnabled () == true) {
				arrowScrFrnd.TurnArrow (randFriend);
			}

            // TODO Replace this implementation to remove cast
			//gameBosScr.setFriendSpriteIndex (randFriend);
            gameBosScr.setFriendPose((MGDirectionUtils.MGDirection)randFriend);

		}
			

		mainTimer -= Time.deltaTime;
		

	}
}
