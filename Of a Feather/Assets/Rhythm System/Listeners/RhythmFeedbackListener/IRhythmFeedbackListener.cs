using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// IRhythmFeedbackListener
//
// Description: Interface for when the RhythmCore registers a hit, miss, or
//  timeout of a particular beat event. Each of these events will coincide with
//  an expiration event for the current beat, which can be detected through
//  the IRhythmQueueEventListener interface.
//
// -----------------------------------------------------------------------------

interface IRhythmFeedbackListener 
{
    void HitNotify();
    void MissNotify();
    void TimeoutNotify();
}
