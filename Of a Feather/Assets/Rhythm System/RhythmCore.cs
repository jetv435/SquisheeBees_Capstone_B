using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// RhythmCore
//
// Description: Component, permits specifying rhythm timing parametrically, and
//  indicating objects which receive "Beat" events, and "Hit", "Miss", and
//  "Timeout" events. On start, initiates beats at a specific interval, tracking
//  and providing feedback for success or failure in a rhythm game context.
//
// -----------------------------------------------------------------------------

public class RhythmCore : MonoBehaviour
{
    [System.Serializable]
    public struct BeatInfo
    {
        public float beatTime;
    }

    [System.Serializable]
    public struct BeatTimingSettings
    {
        public BeatTimingSettings(uint bpm, uint tpl)
        {
            this.beatsPerMinute = bpm;
            this.ticksPerLine = tpl;
        }

        public uint beatsPerMinute;
        public uint ticksPerLine;
    }

    [System.Serializable]
    public struct RhythmExpectedEventInfo
    {
        public KeyCode expectedKey;
    }

    private static readonly BeatTimingSettings defaultBeatTiming = new BeatTimingSettings(60, 24);
    public BeatTimingSettings beatTiming = defaultBeatTiming;
    public float beatWindowDuration = 0.5f;
    public GameObject[] promptListeners;
    public GameObject[] feedbackListeners;
    private readonly ABeatGenerationStrategy beatGenStrat = new RandomArrowGenStrat();
    private RhythmExpectedEventInfo currExpectedEvent;
    private bool bBeatQueued = false;

    // Use this for initialization
    void Start()
    {
        // Adjust the beat window if it exceeds the time between beats
        this.beatWindowDuration = Mathf.Min(this.beatWindowDuration, this.SecondsPerLine());

        this.Invoke("OnBeat", this.SecondsPerLine());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(this.bBeatQueued == true && this.currExpectedEvent.expectedKey == KeyCode.UpArrow)
            {
                this.NotifyHitListeners();
            }
            else
            {
                this.NotifyMissListeners();
            }
            this.bBeatQueued = false;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(this.bBeatQueued == true && this.currExpectedEvent.expectedKey == KeyCode.DownArrow)
            {
                this.NotifyHitListeners();
            }
            else
            {
                this.NotifyMissListeners();
            }
            this.bBeatQueued = false;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(this.bBeatQueued == true && this.currExpectedEvent.expectedKey == KeyCode.LeftArrow)
            {
                this.NotifyHitListeners();
            }
            else
            {
                this.NotifyMissListeners();
            }
            this.bBeatQueued = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(this.bBeatQueued == true && this.currExpectedEvent.expectedKey == KeyCode.RightArrow)
            {
                this.NotifyHitListeners();
            }
            else
            {
                this.NotifyMissListeners();
            }
            this.bBeatQueued = false;
        }
    }

    // Invoked periodically
    private void OnBeat()
    {
        // Generate an expected event for this beat frame via a strategy object, and notify listeners
        this.currExpectedEvent = this.beatGenStrat.GenerateExpectedEvent();
        this.bBeatQueued = true;
        this.NotifyPromptListeners(this.currExpectedEvent);
        this.Invoke("OffBeat", beatWindowDuration);

        // Invoke OnBeat after delay
        this.Invoke("OnBeat", this.SecondsPerLine());
    }

    private void OffBeat()
    {
        if (this.bBeatQueued == true)
        {
            // If beat is still queued, then it wasn't hit and should timeout
            this.NotifyTimeoutListeners();

            // Expire the current expected event, and notify listeners
            this.bBeatQueued = false;
        }
    }

    private void NotifyPromptListeners(RhythmCore.RhythmExpectedEventInfo eventInfo)
    {
        foreach (GameObject listenerObject in this.promptListeners)
        {
            IRhythmPromptListener[] listenerComponents = listenerObject.GetComponents<IRhythmPromptListener>();

            if (listenerComponents.Length != 0)
            {
                foreach (IRhythmPromptListener listenerComponent in listenerComponents)
                {
                    listenerComponent.PromptNotify(eventInfo);
                }
            }
            else
            {
                Debug.LogError("GameObject indicated in BeatKeeper missing IRhythmQueueEventListener component(s)");
            }
        }
    }

    private void NotifyHitListeners()
    {
        foreach (GameObject listenerObject in this.feedbackListeners)
        {
            IRhythmFeedbackListener[] listenerComponents = listenerObject.GetComponents<IRhythmFeedbackListener>();

            if (listenerComponents.Length != 0)
            {
                foreach (IRhythmFeedbackListener listenerComponent in listenerComponents)
                {
                    listenerComponent.HitNotify();
                }
            }
            else
            {
                Debug.LogError("GameObject indicated in BeatKeeper missing IRhythmFeedbackListener component(s)");
            }
        }
    }

    private void NotifyMissListeners()
    {
        foreach (GameObject listenerObject in this.feedbackListeners)
        {
            IRhythmFeedbackListener[] listenerComponents = listenerObject.GetComponents<IRhythmFeedbackListener>();

            if (listenerComponents.Length != 0)
            {
                foreach (IRhythmFeedbackListener listenerComponent in listenerComponents)
                {
                    listenerComponent.MissNotify();
                }
            }
            else
            {
                Debug.LogError("GameObject indicated in BeatKeeper missing IRhythmFeedbackListener component(s)");
            }
        }
    }

    private void NotifyTimeoutListeners()
    {
        foreach (GameObject listenerObject in this.feedbackListeners)
        {
            IRhythmFeedbackListener[] listenerComponents = listenerObject.GetComponents<IRhythmFeedbackListener>();

            if (listenerComponents.Length != 0)
            {
                foreach (IRhythmFeedbackListener listenerComponent in listenerComponents)
                {
                    listenerComponent.TimeoutNotify();
                }
            }
            else
            {
                Debug.LogError("GameObject indicated in BeatKeeper missing IRhythmFeedbackListener component(s)");
            }
        }
    }

    private float SecondsPerLine()
    {
        if (this.beatTiming.beatsPerMinute == 0)
        {
            Debug.LogError("BeatKeeper time parameter(s) invalid");
        }

        return (60.0f * this.beatTiming.ticksPerLine) / (24.0f * this.beatTiming.beatsPerMinute);
    }
}
