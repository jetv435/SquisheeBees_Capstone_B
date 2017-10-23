using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// NullBeatListener
//
// Description: Does nothing on BeatNotify.
//
// -----------------------------------------------------------------------------

public class NullBeatListener : MonoBehaviour, IBeatListener
{
    public void BeatNotify(RhythmCore.BeatInfo beatInfo)
    {
        // Default NULL behavior for BeatNotify
    }
}
