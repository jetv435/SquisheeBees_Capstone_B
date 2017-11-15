using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlayerScript : MonoBehaviour {
	
	GameObject MainCamera;
	Camera mainCamCamObj;
	bool carrying = false;

	Rigidbody cObjRBody;

	GameObject carriedObj;

	public float distance = 3;
	public float smooth = 4;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamCamObj = MainCamera.GetComponent<Camera> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (carrying) {
			carryFunc (carriedObj);
			checkDropFunc ();
		} else {
			pickUpFunc ();
		}
		
	}

	void carryFunc (GameObject carryThing)
	{
		

		cObjRBody.transform.position = Vector3.Lerp(cObjRBody.transform.position,MainCamera.transform.position + MainCamera.transform.forward * distance, Time.deltaTime *smooth);
	}

	void pickUpFunc()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray rayCheck = mainCamCamObj.ScreenPointToRay(new Vector3(x,y));
			RaycastHit hitCheck;
			if (Physics.Raycast (rayCheck, out hitCheck)) {
				PickupableScript p = hitCheck.collider.GetComponent<PickupableScript> ();
				if (p != null) {
					carrying = true;
					carriedObj = p.gameObject;

					cObjRBody = p.gameObject.GetComponent<Rigidbody> ();
					cObjRBody.useGravity = false;
				}
			}
		}
	}

	void checkDropFunc()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			dropObject ();
		}
	}

	void dropObject()
	{
		carrying = false;

		cObjRBody.useGravity = true;
		cObjRBody = null;

		carriedObj = null;
	}
}



////
/// Source: https://www.youtube.com/watch?v=runW-mf1UH0&index=3&list=WL
////
