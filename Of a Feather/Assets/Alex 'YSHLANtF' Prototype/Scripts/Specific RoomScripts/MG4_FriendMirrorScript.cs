using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG4_FriendMirrorScript : MonoBehaviour {

	GameObject playerObject;
	Vector3 mirroredPlayerTransform;

	// Use this for initialization
	void Start () {

		playerObject = GameObject.FindGameObjectWithTag("Player");
		mirroredPlayerTransform = playerObject.transform.position;
		mirroredPlayerTransform.x *= -1;
		transform.position = mirroredPlayerTransform;
		
	}
	
	// Update is called once per frame
	void Update () {

		mirroredPlayerTransform = playerObject.transform.position;
		mirroredPlayerTransform.x *= -1;
		transform.position = mirroredPlayerTransform;
		
	}
}
