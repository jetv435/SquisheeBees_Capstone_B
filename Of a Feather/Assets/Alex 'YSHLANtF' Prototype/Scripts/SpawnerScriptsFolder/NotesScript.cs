using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour {

	public float speed = 1; //This is going to be hundredth'd

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MoveNote ();
		TooHigh ();
	}

	void MoveNote()
	{
		transform.Translate (transform.up * speed * 0.01f);
	}

	void TooHigh()
	{
		if (transform.position.y > 10) {//Subject to change
			Destroy(gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
