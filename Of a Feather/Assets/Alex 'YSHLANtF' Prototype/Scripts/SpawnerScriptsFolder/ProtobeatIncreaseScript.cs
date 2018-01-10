using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtobeatIncreaseScript : MonoBehaviour {

	public GameObject BeatObjCall;
	RhythmCore BeatScrCall;

	// Use this for initialization
	void Start () {
		BeatScrCall = BeatObjCall.GetComponent<RhythmCore> ();

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
			}
		}
		
	}
}
