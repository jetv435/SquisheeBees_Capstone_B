using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3and4SpriteControlScript : MonoBehaviour {

	public GameObject playerObject;
	public List<Sprite> playerSprites = new List<Sprite>();
	public Sprite idleSprite;
	public bool isFriend = false;
	MG4_FriendGrabScript minigameFourFriendGrabCall;

	// Use this for initialization
	void Start () {

		if (isFriend == true) {
			minigameFourFriendGrabCall = playerObject.GetComponent<MG4_FriendGrabScript> ();
		} else
			minigameFourFriendGrabCall = null;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				SpriteShiftFunction (0);
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				SpriteShiftFunction (1);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				SpriteShiftFunction (2);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow)) {
				SpriteShiftFunction (3);
			}
		}
		
	}

	void SpriteShiftFunction(int keyShifter)
	{
		if (isFriend == false || isFriend == true && minigameFourFriendGrabCall.GiveFriendMovementBool ()) {
			SpriteRenderer temp = playerObject.GetComponent<SpriteRenderer> ();

			temp.sprite = playerSprites [keyShifter];

			CancelInvoke ();

			Invoke ("idleFunction", 1);
		}

	}

	void idleFunction()
	{
		SpriteRenderer temp = playerObject.GetComponent<SpriteRenderer> ();

		temp.sprite = idleSprite;
	}
}
