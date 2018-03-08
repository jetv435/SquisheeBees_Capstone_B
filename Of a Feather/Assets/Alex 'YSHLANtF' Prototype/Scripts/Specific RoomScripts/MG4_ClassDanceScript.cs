using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG4_ClassDanceScript : MonoBehaviour {

	public List<Sprite> classDanceSprites = new List<Sprite> ();
	public List<GameObject> listOfClassObjects = new List<GameObject>();
	public GameObject friendObject;
	MG4_FriendGrabScript friendScript;
	public List<Sprite> friendDanceSprites = new List<Sprite>();
	int randomizer = 0;
	int prevRand = -1;

	public float timeToChangeStances = 1.5f;

	// Use this for initialization
	void Start () {

		friendScript = friendObject.GetComponent<MG4_FriendGrabScript> ();

		Invoke ("ChangeStanceNow", timeToChangeStances);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeStanceNow()
	{


		randomizer = Random.Range (0, classDanceSprites.Count);
		while (randomizer == prevRand) {
			randomizer = Random.Range (0, classDanceSprites.Count);
		}

		prevRand = randomizer;

		for (int i = 0; i < listOfClassObjects.Count; i++) {
			SpriteRenderer temp = listOfClassObjects [i].GetComponent<SpriteRenderer> ();

			temp.sprite = classDanceSprites [randomizer];

		}
		if (friendScript.GiveFriendMovementBool() == false) {
			SpriteRenderer temp = friendObject.GetComponent<SpriteRenderer> ();

			temp.sprite = friendDanceSprites [randomizer];
		}

		Invoke ("ChangeStanceNow", timeToChangeStances);


	}
}
