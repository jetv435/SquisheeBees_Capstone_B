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

    public static RhythmCore.RhythmExpectedEventInfo GenerateExpectedEventStatic(ref RhythmCore.RhythmExpectedEventInfo prev)
    {
        // Generate a non-repeating prompt arrow direction
        RhythmCore.RhythmExpectedEventInfo retInfo = RandomArrowGenStrat.GenerateExpectedEventStatic();
        while (retInfo.expectedKey == prev.expectedKey)
        {
            retInfo = RandomArrowGenStrat.GenerateExpectedEventStatic();
        }

        // Set this.prevInfo to track the previous key this strategy generated
        prev = retInfo;

        // Return
        return retInfo;
    }

    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        return GenerateExpectedEventStatic(ref this.prevInfo);
    }
}
