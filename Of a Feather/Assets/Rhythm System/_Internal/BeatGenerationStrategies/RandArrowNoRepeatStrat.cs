using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandArrowNoRepeatStrat : ABeatGenerationStrategy
{
    private RhythmCore.RhythmExpectedEventInfo prevInfo;

    public RandArrowNoRepeatStrat()
    {
        // TODO: CAN I set the prevInfo event/key to a "null" value?
    }

    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        // Generate a non-repeating prompt arrow direction
        RhythmCore.RhythmExpectedEventInfo retInfo = RandomArrowGenStrat.GenerateExpectedEventStatic();
        while(retInfo.expectedKey == this.prevInfo.expectedKey)
        {
            retInfo = RandomArrowGenStrat.GenerateExpectedEventStatic();
        }

        // Set this.prevInfo to track the previous key this strategy generated
        this.prevInfo = retInfo;

        // Return
        return retInfo;
    }
}
