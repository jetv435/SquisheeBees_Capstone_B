using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterNoteScript : MonoBehaviour {

	bool keepOnGoing = true;
	Vector2 oriPos;

	// Use this for initialization
	void Start () {
		oriPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			transform.position = oriPos;
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
