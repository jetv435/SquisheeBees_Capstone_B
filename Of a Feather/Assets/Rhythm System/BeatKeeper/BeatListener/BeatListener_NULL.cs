using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// BeatListener_NULL
//
// Description: Does nothing on BeatNotify.
//
// -----------------------------------------------------------------------------

public class BeatListener_NULL : BeatListener
{
    public override void BeatNotify(BeatKeeper.BeatInfo beatInfo)
    {
        // Default NULL behavior for BeatNotify
    }
}
