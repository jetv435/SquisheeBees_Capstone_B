using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MG4_ExitScript : MonoBehaviour {

	bool friendGrab = false;

	public GameObject friendObjectMG4;
	MG4_FriendGrabScript friendScript;

	// Use this for initialization
	void Start () {

		friendScript = friendObjectMG4.GetComponent<MG4_FriendGrabScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//If friendGrab = false, it sends it to the friendless basement.
		//If friendGrab is true, it sends it to the friend basement.
		friendGrab = friendScript.GiveFriendMovementBool ();

		if (friendGrab == false)
			SceneManager.LoadScene ("Basement5");
		else
			SceneManager.LoadScene ("Basement5");
	}
}
