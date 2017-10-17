using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	public float walkSpeed = 1f;
	public GameObject cameraMain;
	CameraControlScr cameraMainScr;

	Quaternion rotCam;

	// Use this for initialization
	void Start () {

		cameraMainScr = cameraMain.GetComponent<CameraControlScr> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		rotCam = cameraMainScr.giveRotations ();
		TranslateMovement ();
		
	}

	void TranslateMovement()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 localForward = transform.rotation * rotCam * Vector3.forward;
		Vector3 localRight = transform.rotation * rotCam * Vector3.right;

		Vector3 direction = (localForward * (v * walkSpeed)) + (localRight * (h * walkSpeed));

		direction.y = 0;

		direction.x *= .1f;
		direction.z *= .1f;

		transform.position += direction;

	}
}
