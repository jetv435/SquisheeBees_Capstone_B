using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DualRandArrowNoRepeatManager
{
    [System.Serializable]
    public enum PromptSelect
    {
        PROMPT_0,
        PROMPT_1,
        NONE_AVAILABLE
    }

    private enum GeneratorClaimState
    {
        BOTH_AVAILABLE,
        ONLY_SECOND_AVAILABLE,
        NONE_AVAILABLE
    }

    static readonly private RhythmCore.RhythmExpectedEventInfo[] _randomPrompts = new RhythmCore.RhythmExpectedEventInfo[2];
    static readonly private RhythmCore.RhythmExpectedEventInfo[] _prevPrompts = new RhythmCore.RhythmExpectedEventInfo[2];
    static private GeneratorClaimState claimState;

    // generate first set of unique prompts at startup
    static DualRandArrowNoRepeatManager()
    {
        claimState = GeneratorClaimState.BOTH_AVAILABLE;
    }

    static public void Regenerate()
    {
        // generate a non-repeating prompt arrow direction for 0
        _randomPrompts[0] = RandomArrowGenStrat.GenerateExpectedEventStatic();
        while (_randomPrompts[0].expectedKey == _prevPrompts[0].expectedKey)
        {
            _randomPrompts[0] = RandomArrowGenStrat.GenerateExpectedEventStatic();
        }

        // track the previous key generated for 0
        _prevPrompts[0] = _randomPrompts[0];

        // generate a non-repeating prompt arrow direction (taking into account
        //  the prompt we already generated) for 1
        _randomPrompts[1] = RandomArrowGenStrat.GenerateExpectedEventStatic();
        while (_randomPrompts[1].expectedKey == _prevPrompts[1].expectedKey ||
               _randomPrompts[1].expectedKey == _randomPrompts[0].expectedKey)
        {
            _randomPrompts[1] = RandomArrowGenStrat.GenerateExpectedEventStatic();
        }

        // track the previous key generated for 1
        _prevPrompts[1] = _randomPrompts[1];
    }

    static public RhythmCore.RhythmExpectedEventInfo GetPrompt(PromptSelect sel)
    {
        if (sel == PromptSelect.PROMPT_0 || sel == PromptSelect.PROMPT_1)
        {
            return _randomPrompts[(int)sel];
        }
        else
        {
            Debug.LogError("Invalid PrompSelect in DualRandArrowNoRepeatManager.GetPrompt");

            RhythmCore.RhythmExpectedEventInfo ret;
            ret.expectedKey = KeyCode.Escape;
            return ret;
        }
    }

    static public PromptSelect Claim()
    {
        PromptSelect ret = PromptSelect.NONE_AVAILABLE;

        switch(claimState)
        {
            case GeneratorClaimState.BOTH_AVAILABLE:
                {
                    ret = PromptSelect.PROMPT_0;
                    claimState = GeneratorClaimState.ONLY_SECOND_AVAILABLE;
                } break;
            case GeneratorClaimState.ONLY_SECOND_AVAILABLE:
                {
                    ret = PromptSelect.PROMPT_1;
                    claimState = GeneratorClaimState.NONE_AVAILABLE;
                } break;
            case GeneratorClaimState.NONE_AVAILABLE:
                {
                    //Debug.LogError("Too many attempt to claim unique dual-prompt");
                    ret = PromptSelect.NONE_AVAILABLE;
                } break;
            default:
                {
                    Debug.LogError("Unexpected value for claimState in DualRandArrowGenManager.Claim");
                } break;
        }

        return ret;
    }
}

// "he's not a motherless arseface knob-jockey?" -Irish Sod
