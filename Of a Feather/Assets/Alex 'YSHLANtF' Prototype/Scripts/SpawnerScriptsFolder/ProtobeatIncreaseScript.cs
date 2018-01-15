using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtobeatIncreaseScript : MonoBehaviour {

	public GameObject BeatObjCall;
	RhythmCore BeatScrCall;

	public GameObject lightControllerObject;
	LightControlMG2Script lightControlScript;

	// Use this for initialization
	void Start () {
		BeatScrCall = BeatObjCall.GetComponent<RhythmCore> ();

		lightControlScript = lightControllerObject.GetComponent<LightControlMG2Script> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow) || 
			Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {

			if (BeatScrCall.IsBeatQueued () == true) {

				BeatScrCall.beatTiming.beatsPerMinute += 5;
				BeatScrCall.beatTiming.ticksPerLine -= 1;

				if (BeatScrCall.beatTiming.ticksPerLine <= 0)
					BeatScrCall.beatTiming.ticksPerLine = 1;

				lightControlScript.UpdateLightsAndBackground ();
			}
		}
		
	}
}
