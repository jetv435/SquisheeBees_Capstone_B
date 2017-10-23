using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// ABeatGenerationStrategy
//
// Description: Generates an expected event for the RhythmCore (usually a player
//  input from the keyboard) to track during the current beat.
//
// -----------------------------------------------------------------------------

abstract public class ABeatGenerationStrategy
{
    abstract public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent();
}
