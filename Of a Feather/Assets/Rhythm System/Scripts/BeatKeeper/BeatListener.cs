using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// BeatListener
//
// Description: Can register to a BeatKeeper to be notified when beats occur
//
// -----------------------------------------------------------------------------

abstract public class BeatListener
{
    abstract public void BeatNotify(BeatKeeper.BeatInfo beatInfo);
}
