using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	public float walkSpeed = 1f;
	public GameObject cameraMain;
	CameraControlScr cameraMainScr;

	CursorLockMode wantedMode;

	Quaternion rotCam;

	// Use this for initialization
	void Start () {

		cameraMainScr = cameraMain.GetComponent<CameraControlScr> ();

		wantedMode = CursorLockMode.Locked;

		SetCursorState ();
		
	}
	
	// Update is called once per frame
	void Update () {
		SetCursorState ();
		rotCam = cameraMainScr.giveRotations ();
		TranslateMovement ();

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (wantedMode == CursorLockMode.Locked) {
				wantedMode = CursorLockMode.None;
			} else if (wantedMode == CursorLockMode.None) {
				wantedMode = CursorLockMode.Locked;

			}
		}
		
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

	//If player impacts other object, that has rigidbody, it gets pushed away.
	void OnCollisionEnter(Collision other)
	{
		if (other.rigidbody != null) {
			Rigidbody objectRigidBody = other.rigidbody;

			Vector3 forceAway;

			forceAway = other.transform.position - transform.position;

			forceAway.y = other.transform.position.y;

			objectRigidBody.AddForce (forceAway * 20 * objectRigidBody.mass);
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.rigidbody != null) {
			Rigidbody objectRigidBody = other.rigidbody;

			Vector3 forceAway;

			forceAway = other.transform.position - transform.position;

			forceAway.y = other.transform.position.y;

			objectRigidBody.AddForce (forceAway * 20 * objectRigidBody.mass);
		}
	}

	void SetCursorState()
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking

		Cursor.visible = (CursorLockMode.Locked != wantedMode);
		if (wantedMode != CursorLockMode.Locked) {
			Cursor.visible = true;
		}
	}


}
