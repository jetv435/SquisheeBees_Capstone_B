using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutexArrowNoRepeatStrat_B : ABeatGenerationStrategy
{
    private readonly MutexArrowCoordinator _myCoordinator;

    public MutexArrowNoRepeatStrat_B(ref MutexArrowCoordinator myCoordinator)
    {
        this._myCoordinator = myCoordinator;
        this._myCoordinator.RegisterGenerator_B(this);
    }

    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        return this._myCoordinator.GenerateExpectedEvent_B(this);
    }
}
