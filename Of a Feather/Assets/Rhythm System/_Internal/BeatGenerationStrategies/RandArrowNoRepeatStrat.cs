using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandArrowNoRepeatStrat : ABeatGenerationStrategy
{
    private readonly RandomArrowGenStrat randArrowStrat = new RandomArrowGenStrat();
    private RhythmCore.RhythmExpectedEventInfo prevInfo;

    public RandArrowNoRepeatStrat()
    {
        // TODO: CAN I set the prevInfo event/key to a "null" value?
    }

    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        // Generate a non-repeating prompt arrow direction
        RhythmCore.RhythmExpectedEventInfo retInfo = this.randArrowStrat.GenerateExpectedEvent();
        while(retInfo.expectedKey == this.prevInfo.expectedKey)
        {
            retInfo = this.randArrowStrat.GenerateExpectedEvent();
        }

        // Set this.prevInfo to track the previous key this strategy generated
        this.prevInfo = retInfo;

        // Return
        return retInfo;
    }
}
