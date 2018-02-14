using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutexArrowNoRepeatComponent : ABeatGenerationComponent
{
	void Start ()
    {
        // Update() should not be called on this component
        this.enabled = false;	
	}
	
	void Update ()
    {
        Debug.LogError("Update() of MutexArrowNoRepeatComponent called - should not occur.");
	}

    public override ABeatGenerationStrategy GetStrategy()
    {
        // ToDo: Replace this with design-correct code (create Mutex strategies)
        Debug.Log("HORAY: We have successfully provided a custom beat generation strategy to our RhythmCore!");
        return new RandArrowNoRepeatStrat();
    }
}
