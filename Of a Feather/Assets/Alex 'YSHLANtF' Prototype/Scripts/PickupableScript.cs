using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableScript : MonoBehaviour {

	//Calls its own rigidbody
	Rigidbody ownRB;

	// Use this for initialization
	void Start () {

		ownRB = this.gameObject.GetComponent<Rigidbody> ();
		
	}
	
	// FixedUpdate
	void FixedUpdate () {


		
	}

	public void SetVelocity_PutDown (Vector3 newVelocity)
	{

		ownRB.velocity = newVelocity;

	}
		
}
