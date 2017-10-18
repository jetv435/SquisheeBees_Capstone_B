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

	//To alter the note toggling
	GameObject MasterToggle;
	ArrowToggle MasterSwitch;
	bool noteToggle;

	//Change Sprite
	GameObject callSpriteBoss;
	SpriteControllerSprite callSprScr;

	//Lazy arrow call script
	public GameObject arrowObj;
	ArrowTurnScript arrowScr;

	int prevCall = 2;


	// Use this for initialization
	void Start () {

		timerCoolDownSecret = timerCoolDownSec;
		mainTimer = timerCoolDownSec;

		MasterToggle = GameObject.FindGameObjectWithTag ("NoteToggleTag");
		MasterSwitch = MasterToggle.GetComponent<ArrowToggle> ();

		noteToggle = MasterSwitch.returnToggle ();

		if (noteToggle == true) {
			mainNote.transform.position = new Vector2 (-20, -20);
		}

		callSpriteBoss = GameObject.FindGameObjectWithTag ("SpriteController");
		callSprScr = callSpriteBoss.GetComponent<SpriteControllerSprite> ();

		//Really lazy code work
		arrowScr = arrowObj.GetComponent<ArrowTurnScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (noteToggle == true) {
			if (mainTimer <= 0) {
				mainTimer = timerCoolDownSecret + Random.Range (0, 5);
				int randSpawner = Random.Range (0, spawnerList.Count);

				GameObject temp = spawnerList [randSpawner];
				SpawnerScript tempScr = temp.GetComponent<SpawnerScript> ();

				tempScr.SpawnNote ();
			}

			mainTimer -= Time.deltaTime;
		} else {
			if (mainTimer <= 0) {
				mainTimer = timerCoolDownSecret + Random.Range (3, 5);
				int randSpawner = Random.Range (0, playerArrowList.Count);

				while (randSpawner == prevCall) {
					randSpawner = Random.Range (0, playerArrowList.Count);
				}

				prevCall = randSpawner;

				mainNote.transform.position = playerArrowList [randSpawner].transform.position;
				callSprScr.ClassChange (randSpawner);

				arrowScr.TurnArrow (randSpawner);
			}

			mainTimer -= Time.deltaTime;
		}
	}
}
