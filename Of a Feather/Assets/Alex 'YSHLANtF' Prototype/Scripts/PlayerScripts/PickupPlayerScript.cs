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

	private MainMenuManager mm;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamCamObj = MainCamera.GetComponent<Camera> ();
		mm = GameObject.FindGameObjectWithTag ("MManager").GetComponent<MainMenuManager> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (carrying) {
			carryFunc (carriedObj);
			checkDropFunc ();
			if (carrying && carriedObj.tag == "MManager") {
				StartCoroutine (mm.SGCorutine ());
			}

		} else {
			haloActivation ();
			pickUpFunc ();


		}
		
	}

	void carryFunc (GameObject carryThing)
	{
		

		cObjRBody.transform.position = Vector3.Lerp(cObjRBody.transform.position,MainCamera.transform.position + MainCamera.transform.forward * distance, Time.deltaTime *smooth);
	}

	void pickUpFunc()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
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
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			dropObject ();
		}
	}

	void dropObject()
	{
		//Allows the other object to get a new velocity
		PickupableScript callVelocityFunction;
		callVelocityFunction = cObjRBody.GetComponent<PickupableScript> ();


		carrying = false;

		//Sets a new velocity
		callVelocityFunction.SetVelocity_PutDown(cObjRBody.velocity);

		cObjRBody.useGravity = true;
		cObjRBody = null;

		carriedObj = null;
	}

	//Calls the HaloScript
	void haloActivation()
	{
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray rayCheck = mainCamCamObj.ScreenPointToRay(new Vector3(x,y));
		RaycastHit hitCheck;
		if (Physics.Raycast (rayCheck, out hitCheck)) {
			HaloControllerPickupScript h = hitCheck.collider.GetComponent<HaloControllerPickupScript> ();
			if (h != null) {
				h.HaloActivation (true);
				
			}
		}

	}
}



////
/// Source: https://www.youtube.com/watch?v=runW-mf1UH0&index=3&list=WL
////
