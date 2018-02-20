using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG4_FriendGrabScript : MonoBehaviour {

	bool moveWithPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (moveWithPlayer)
			moveFunction ();
	}

	void moveFunction()
	{
		if (gameObject.transform.position.y != gameObject.transform.parent.position.y) {
			Vector2 setY = new Vector2 (gameObject.transform.position.x, gameObject.transform.parent.position.y);
			gameObject.transform.position = setY;
		}
		if (gameObject.transform.position.x != gameObject.transform.parent.transform.position.x + (gameObject.transform.parent.transform.localScale.x * 4)) {
			Vector2 setX = new Vector2 (gameObject.transform.parent.position.x + (gameObject.transform.parent.transform.localScale.x * 4), gameObject.transform.position.y);
			gameObject.transform.position = setX;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {

			moveWithPlayer = true;

			gameObject.transform.parent = other.transform;

		}
	}
}
