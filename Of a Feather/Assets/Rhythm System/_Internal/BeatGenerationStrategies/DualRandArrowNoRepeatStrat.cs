using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualRandArrowNoRepeatStrat : ABeatGenerationStrategy
{
    private readonly DualRandArrowNoRepeatManager.PromptSelect promptKey = DualRandArrowNoRepeatManager.PromptSelect.UNSET;

    public DualRandArrowNoRepeatStrat()
    {
        DualRandArrowNoRepeatManager.PromptSelect claimRet = DualRandArrowNoRepeatManager.Claim();
        if (claimRet != DualRandArrowNoRepeatManager.PromptSelect.UNSET)
        {
            this.promptKey = claimRet;
        }
    }

    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        return DualRandArrowNoRepeatManager.GetPrompt(this.promptKey);
    }
}
