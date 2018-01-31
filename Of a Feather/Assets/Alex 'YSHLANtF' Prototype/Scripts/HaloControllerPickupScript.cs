using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloControllerPickupScript : MonoBehaviour {

	Component haloComp;
	//Second based
	float timerCounter = 0;

	// Use this for initialization
	void Start () {

		haloComp = GetComponent ("Halo");
		haloComp.GetType ().GetProperty ("enabled").SetValue (haloComp, false, null);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timerCounter > 0) {
			timerCounter -= Time.deltaTime;
		} else if (timerCounter <= 0) {
			haloComp.GetType ().GetProperty ("enabled").SetValue (haloComp, false, null);
		}
		
	}


	public void HaloActivation(bool activator)
	{
		haloComp.GetType ().GetProperty ("enabled").SetValue (haloComp, activator, null);
		timerCounter = .1f;

	}
}
