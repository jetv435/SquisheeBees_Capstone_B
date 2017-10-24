using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArrowGenStrat : ABeatGenerationStrategy
{
    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        int keyRandomizer = Random.Range(0, 4);

        KeyCode selectedKey = KeyCode.UpArrow;
        switch(keyRandomizer)
        {
            case 0:
                {
                    selectedKey = KeyCode.UpArrow;
                    break;
                }
            case 1:
                {
                    selectedKey = KeyCode.DownArrow;
                    break;
                }
            case 2:
                {
                    selectedKey = KeyCode.LeftArrow;
                    break;
                }
            case 3:
                {
                    selectedKey = KeyCode.RightArrow;
                    break;
                }
            default:
                {
                    Debug.LogError("Unexpected keyRandomizer value in RandomArrowGenStrat.GenerateExpectedEvent");
                    break;
                }
        }

        // Should return, at random, either the Up, Down, Left, or Right arrow
        //  keys
        return new RhythmCore.RhythmExpectedEventInfo()
        {
            expectedKey = selectedKey
        };
    }
}
