using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// IRhythmQueueEventListener
//
// Description: Interface for when the RhythmCore queues a Rhythm event, or when
//  a/the currently-active Rhythm event expires. This does not indicate whether
//  or not the event was satisfied; this can be detected by implementing the
//  IRhythmFeedbackListener interface.
//
// -----------------------------------------------------------------------------

interface IRhythmQueueEventListener
{
    void EventQueuedNotify(RhythmCore.RhythmExpectedEventInfo eventInfo);
    void EventExpiredNotify(RhythmCore.RhythmExpectedEventInfo eventInfo);
}
