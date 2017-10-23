using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// IBeatListener
//
// Description: Interface for beat notifications from RhythmCore
//
// -----------------------------------------------------------------------------

interface IBeatListener
{
    void BeatNotify(RhythmCore.BeatInfo beatInfo);
}
