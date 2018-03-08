using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtobeatIncreaseScript : MonoBehaviour {

	public GameObject BeatObjCall;
	RhythmCore BeatScrCall;

	public uint maxBPM = 200;
	public uint minTPL = 1;
	public int buttonPressesBeforeQuickening = 7;
	int buttonPresses = 0;

	public GameObject lightControllerObject;
	LightControlMG2Script lightControlScript;

	public GameObject sControlObject;
	SpriteControllerSprite sControlScript;



	// Use this for initialization
	void Start () {
		BeatScrCall = BeatObjCall.GetComponent<RhythmCore> ();

		sControlScript = sControlObject.GetComponent<SpriteControllerSprite> ();

		lightControlScript = lightControllerObject.GetComponent<LightControlMG2Script> ();



	}
	
	// Update is called once per frame
	void Update () {
		if (BeatScrCall.IsBeatQueued () == true) {

			sControlScript.CancelInvokingFunction ();

		}
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow) || 
			Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {

			//if (BeatScrCall.IsBeatQueued () == true) {

				if (buttonPresses >= buttonPressesBeforeQuickening) {
					
					if (BeatScrCall.beatTiming.beatsPerMinute < maxBPM) {
						BeatScrCall.beatTiming.beatsPerMinute += 5;
					}
					if (BeatScrCall.beatTiming.ticksPerLine > minTPL) {
						BeatScrCall.beatTiming.ticksPerLine -= 1;
					}

					if (BeatScrCall.beatTiming.ticksPerLine <= 0)
						BeatScrCall.beatTiming.ticksPerLine = 1;

					lightControlScript.UpdateLightsAndBackground ();
				} else {
					buttonPresses++;
				}
			//}
		}
		
	}
}
