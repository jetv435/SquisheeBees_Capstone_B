using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutexArrowCoordinator : MonoBehaviour
{
    private enum State
    {
        WAITING_FOR_FIRST,
        A_REQUESTED_B_PENDING,
        B_REQUESTED_A_PENDING,
        GENERATOR_REGISTRATION_PENDING,
    }

    private State _myState = State.GENERATOR_REGISTRATION_PENDING;

    private MutexArrowNoRepeatStrat_A _genStratA = null;
    private MutexArrowNoRepeatStrat_B _genStratB = null;
    private RhythmCore.RhythmExpectedEventInfo currInfoA;
    private RhythmCore.RhythmExpectedEventInfo currInfoB;
    private RhythmCore.RhythmExpectedEventInfo prevInfoA;
    private RhythmCore.RhythmExpectedEventInfo prevInfoB;

	void Start ()
    {
        this.enabled = false;
	}
	
	void Update ()
    {
        Debug.LogError("Update() of MutexArrowCoordinator called - should not occur.");
	}

    public void RegisterGenerator_A(MutexArrowNoRepeatStrat_A generatorA)
    {
        if (this._genStratA == null)
        {
            this._genStratA = generatorA;

            // once we have both A and B, start waiting for requests
            if(this._genStratB != null)
            {
                this._myState = State.WAITING_FOR_FIRST;
                Debug.Log("RegisterGenerator_A -> WAITING_FOR_FIRST");
            }
        }
        else
        {
            Debug.LogError("Attempting to register another A generator to MutexArrowCoordinator is an error");    
        }
    }

    public void RegisterGenerator_B(MutexArrowNoRepeatStrat_B generatorB)
    {
        if (this._genStratB == null)
        {
            this._genStratB = generatorB;

            // once we have both A and B, start waiting for requests
            if (this._genStratA != null)
            {
                this._myState = State.WAITING_FOR_FIRST;
                Debug.Log("RegisterGenerator_B -> WAITING_FOR_FIRST");
            }
        }
        else
        {
            Debug.LogError("Attempting to register another B generator to MutexArrowCoordinator is an error");   
        }
    }

    public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent_A(MutexArrowNoRepeatStrat_A strat)
    {
        RhythmCore.RhythmExpectedEventInfo ret;

        if(strat == this._genStratA)
        {
            // Generate a non-repeating prompt arrow direction
            this.currInfoA = RandomArrowGenStrat.GenerateExpectedEventStatic();

            if (_myState == State.WAITING_FOR_FIRST)
            {
                while (this.currInfoA.expectedKey == this.prevInfoA.expectedKey)
                {
                    this.currInfoA = RandomArrowGenStrat.GenerateExpectedEventStatic();
                }
                this._myState = State.A_REQUESTED_B_PENDING;
                Debug.Log("GenerateExpectedEvent_A -> A_REQUESTED_B_PENDING");
            }
            else if(_myState == State.B_REQUESTED_A_PENDING)
            {
                while (this.currInfoA.expectedKey == this.prevInfoA.expectedKey && this.currInfoA.expectedKey == this.currInfoB.expectedKey)
                {
                    this.currInfoA = RandomArrowGenStrat.GenerateExpectedEventStatic();
                }
                this._myState = State.WAITING_FOR_FIRST;
                Debug.Log("GenerateExpectedEvent_A -> WAITING_FOR_FIRST");
            }
            else
            {
                Debug.LogError("Invalid state in MutexArrowCoordinator.GenerateExpectedEvent_A");    
            }

            // Set this.prevInfo to track the previous key this strategy generated
            this.prevInfoA = this.currInfoA;

            // Return
            ret = this.currInfoA;
        }
        else
        {
            Debug.LogError("MutexArrowNoRepeatStrat_A passed into GenerateExpectedEvent_A does not match registered strategy");
            ret = new RhythmCore.RhythmExpectedEventInfo()
            {
                expectedKey = KeyCode.A
            };
        }

        return ret;
    }

    public RhythmCore.RhythmExpectedEventInfo GenerateExpectedEvent_B(MutexArrowNoRepeatStrat_B strat)
    {
        RhythmCore.RhythmExpectedEventInfo ret;

        if (strat == this._genStratB)
        {
            // Generate a non-repeating prompt arrow direction
            this.currInfoB = RandomArrowGenStrat.GenerateExpectedEventStatic();

            if (_myState == State.WAITING_FOR_FIRST)
            {
                while (this.currInfoB.expectedKey == this.prevInfoB.expectedKey)
                {
                    this.currInfoB = RandomArrowGenStrat.GenerateExpectedEventStatic();
                }
                this._myState = State.B_REQUESTED_A_PENDING;
                Debug.Log("GenerateExpectedEvent_B -> B_REQUESTED_A_PENDING");
            }
            else if (_myState == State.A_REQUESTED_B_PENDING)
            {
                while (this.currInfoB.expectedKey == this.prevInfoB.expectedKey && this.currInfoB.expectedKey == this.currInfoA.expectedKey)
                {
                    this.currInfoB = RandomArrowGenStrat.GenerateExpectedEventStatic();
                }
                this._myState = State.WAITING_FOR_FIRST;
                Debug.Log("GenerateExpectedEvent_B -> WAITING_FOR_FIRST");
            }
            else
            {
                Debug.LogError("Invalid state in MutexArrowCoordinator.GenerateExpectedEvent_B");
            }

            // Set this.prevInfo to track the previous key this strategy generated
            this.prevInfoB = this.currInfoB;

            // Return
            ret = this.currInfoB;
        }
        else
        {
            Debug.LogError("MutexArrowNoRepeatStrat_A passed into GenerateExpectedEvent_A does not match registered strategy");
            ret = new RhythmCore.RhythmExpectedEventInfo()
            {
                expectedKey = KeyCode.A
            };
        }

        return ret;
    }
}
