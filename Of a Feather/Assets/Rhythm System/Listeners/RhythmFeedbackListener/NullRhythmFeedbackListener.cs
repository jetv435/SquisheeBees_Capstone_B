using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullRhythmFeedbackListener : MonoBehaviour, IRhythmFeedbackListener
{
    public void HitNotify()
    {
        // Do nothing
    }

    public void MissNotify()
    {
        // Do nothing
    }

    public void TimeoutNotify()
    {
        // Do nothing
    }
}
