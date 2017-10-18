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

	// Use this for initialization
	void Start ()
    {
        Invoke("OnBeat", this.SecondsPerLine());
	}

    public bool RegisterBeatListener(ref BeatListener listener)
    {
        this.beatListeners.Add(listener);
        return true;
    }

    // Invoked periodically
    private void OnBeat()
    {
        BeatInfo placeholderInfo = new BeatInfo();
        placeholderInfo.beatTime = Time.timeSinceLevelLoad;

        foreach(BeatListener listener in this.beatListeners)
        {
            listener.BeatNotify(placeholderInfo);
        }

        Invoke("OnBeat", this.SecondsPerLine());
    }

    private float SecondsPerLine()
    {
        if(this.beatsPerMinute == 0)
        {
            Debug.LogError("BeatKeeper time parameter(s) invalid");
        }

        return (60.0f * this.ticksPerLine) / (24.0f * this.beatsPerMinute);
    }

    public uint beatsPerMinute = 125;
    public uint ticksPerLine = 6;
    public List<BeatListener> beatListeners = new List<BeatListener>();
}
