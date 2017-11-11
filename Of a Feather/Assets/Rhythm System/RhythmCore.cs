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
    public GameObject[] promptListenerObjects;
    public GameObject[] feedbackListenerObjects;
    private readonly ABeatGenerationStrategy beatGenStrat = new RandArrowNoRepeatStrat();
    private List<IRhythmPromptListener> promptListeners = new List<IRhythmPromptListener>();
    private List<IRhythmFeedbackListener> feedbackListeners = new List<IRhythmFeedbackListener>();
    private RhythmExpectedEventInfo currExpectedEvent;
    private bool bBeatQueued = false;

    // Use this for initialization
    void Start()
    {
        // Adjust the beat window if it exceeds the time between beats
        this.beatWindowDuration = Mathf.Min(this.beatWindowDuration, this.SecondsPerLine());

        // Get IRhythmPromptListener components from objects in this.promptListenerObjects
        this.CompontsOfTypeFromObjects<IRhythmPromptListener>(this.promptListenerObjects, this.promptListeners);

        // Get IRhythmFeedbackListener components from objects in this.feedbackListenerObjects
        this.CompontsOfTypeFromObjects<IRhythmFeedbackListener>(this.feedbackListenerObjects, this.feedbackListeners);

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

            this.bBeatQueued = false;
        }
    }

    private void CompontsOfTypeFromObjects<T>(GameObject[] sourceGameObjects, List<T> destList)
    {
        foreach (GameObject objects in sourceGameObjects)
        {
            T[] components = objects.GetComponents<T>();

            if (components.Length != 0)
            {
                foreach (T component in components)
                {
                    destList.Add(component);
                }
            }
            else
            {
                Debug.LogError("Component of given type not found in ComponentsFromObjects");
            }
        }
    }

    private void NotifyPromptListeners(RhythmCore.RhythmExpectedEventInfo eventInfo)
    {
        foreach(IRhythmPromptListener listenerComponent in this.promptListeners)
        {
            listenerComponent.PromptNotify(eventInfo);
        }
    }

    private void NotifyHitListeners()
    {
        foreach (IRhythmFeedbackListener listenerComponent in this.feedbackListeners)
        {
            listenerComponent.HitNotify();
        }
    }

    private void NotifyMissListeners()
    {
        foreach (IRhythmFeedbackListener listenerComponent in this.feedbackListeners)
        {
            listenerComponent.MissNotify();
        }
    }

    private void NotifyTimeoutListeners()
    {
        foreach (IRhythmFeedbackListener listenerComponent in this.feedbackListeners)
        {
            listenerComponent.TimeoutNotify();
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
