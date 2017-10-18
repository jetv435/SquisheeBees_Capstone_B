using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// BeatListener_PrintTime
//
// Description: prints the time that beats occur
//
// -----------------------------------------------------------------------------

public class BeatListener_PrintTime : BeatListener
{
    public override void BeatNotify(BeatKeeper.BeatInfo beatInfo)
    {
        Debug.Log("Beat " + beatInfo.beatTime);
    }
}
