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

    [System.Serializable]
    public struct TimeInfo
    {
        public uint beatsPerMinute;
        public uint ticksPerLine;
    }

    public TimeInfo timeSettings = new TimeInfo();
    private List<BeatListener> beatListeners = new List<BeatListener>();

	// Use this for initialization
	void Start ()
    {
        Invoke("OnBeat", this.SecondsPerLine());
	}

    public bool RegisterBeatListener(BeatListener listener)
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
        if(this.timeSettings.beatsPerMinute == 0)
        {
            Debug.LogError("BeatKeeper time parameter(s) invalid");
        }

        return (60.0f * this.timeSettings.ticksPerLine) / (24.0f * this.timeSettings.beatsPerMinute);
    }
}
