using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTest_Script : MonoBehaviour
{
    public uint beatsPerMinute;
    public uint ticksPerLine;

	// Use this for initialization
	void Start ()
    {
        bKeeper_GObj = new GameObject("BeatTest_Script's BeatKeeper");
        this.bKeeper_GObj.AddComponent<BeatKeeper>();
        BeatKeeper bKeeper = this.bKeeper_GObj.GetComponent<BeatKeeper>();
        bKeeper.beatsPerMinute = beatsPerMinute;
        bKeeper.ticksPerLine = ticksPerLine;
        bKeeper.RegisterBeatListener(ref bListener);
	}
	
	//// Update is called once per frame
	//void Update ()
    //{
	//	
	//}

    private GameObject bKeeper_GObj;
    private BeatListener bListener = new BeatListener_PrintTime();
}
