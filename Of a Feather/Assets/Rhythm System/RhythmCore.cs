using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmCore : MonoBehaviour
{
    public BeatKeeper.TimeInfo timeSettings = new BeatKeeper.TimeInfo();
    //public Command hitCommand;
    private BeatKeeper bKeeper;
    private readonly BeatListener bListener = new BeatListener_PrintTime();

	// Use this for initialization
	void Start ()
    {
        // Add a BeatKeeper component
        this.bKeeper = this.gameObject.AddComponent<BeatKeeper>();
        this.bKeeper.timeSettings = this.timeSettings;

        // Register our concrete BeatListener to the BeatKeeper
        this.bKeeper.RegisterBeatListener(this.bListener);
	}
	
	//// Update is called once per frame
	//void Update ()
    //{
	//	
	//}
}
