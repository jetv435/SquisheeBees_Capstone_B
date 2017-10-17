using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// BeatKeeper
//
// Description: For all registered listeners, notifies them when a beat has
//  occurred.
//
// -----------------------------------------------------------------------------

public class BeatKeeper : MonoBehaviour
{
    public struct BeatInfo
    {
        public float beatTime;
    }

    public uint beatsPerMinute;
    public uint ticksPerLine;

	// Use this for initialization
	void Start ()
    {
        this.beatListeners = new List<BeatListener>();

        Invoke("OnBeat", this.SecondsPerLine());
	}

    //// Update is called once per frame
    //void Update ()
    //{
    //	
    //}

    public bool RegisterBeatListener(ref BeatListener listener)
    {
        this.beatListeners.Add(listener);

        return false;
    }

    // Invoked periodically
    private void OnBeat()
    {
        BeatInfo placeholderInfo = new BeatInfo();
        placeholderInfo.beatTime = 1.0f;

        foreach(BeatListener listener in this.beatListeners)
        {
            listener.BeatNotify(placeholderInfo);
        }

        Invoke("OnBeat", this.SecondsPerLine());
    }

    private float SecondsPerLine()
    {
        return (60.0f * this.ticksPerLine) / (24.0f * this.beatsPerMinute);
    }

    private List<BeatListener> beatListeners;

}
