using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualRandArrowNoRepeatStrat : ABeatGenerationStrategy
{
    private readonly DualRandArrowNoRepeatManager.PromptSelect prompt = DualRandArrowNoRepeatManager.PromptSelect.NONE_AVAILABLE;

    public DualRandArrowNoRepeatStrat()
    {
        DualRandArrowNoRepeatManager.PromptSelect claimRet = DualRandArrowNoRepeatManager.Claim();
        if (claimRet != DualRandArrowNoRepeatManager.PromptSelect.NONE_AVAILABLE)
        {
            this.prompt = claimRet;
        }
    }

    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        return DualRandArrowNoRepeatManager.GetPrompt(this.prompt);
    }
}
