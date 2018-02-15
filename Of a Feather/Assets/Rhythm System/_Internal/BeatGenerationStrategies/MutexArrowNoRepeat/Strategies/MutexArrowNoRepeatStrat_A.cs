using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutexArrowNoRepeatStrat_A : ABeatGenerationStrategy
{
    private readonly MutexArrowCoordinator _myCoordinator;

    public MutexArrowNoRepeatStrat_A(ref MutexArrowCoordinator myCoordinator)
    {
        this._myCoordinator = myCoordinator;
        this._myCoordinator.RegisterGenerator_A(this);
    }

    override public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent()
    {
        return this._myCoordinator.GenerateExpectedEvent_A(this);
    }
}
