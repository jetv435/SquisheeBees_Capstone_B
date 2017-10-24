using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IRhythmPromptListener
{
    void PromptNotify(RhythmCore.RhythmExpectedEventInfo eventInfo);
}
