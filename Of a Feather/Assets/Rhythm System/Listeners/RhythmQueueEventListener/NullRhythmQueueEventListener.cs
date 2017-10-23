using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullRhythmQueueEventListener : MonoBehaviour, IRhythmQueueEventListener
{
    public void EventQueuedNotify(RhythmCore.RhythmExpectedEventInfo eventInfo)
    {
        // Do nothing
    }

    public void EventExpiredNotify(RhythmCore.RhythmExpectedEventInfo eventInfo)
    {
        // Do nothing
    }
}
