using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutexArrowNoRepeatComponent : ABeatGenerationComponent
{
    [System.Serializable]
    public enum CoordinatedGeneratorID
    {
        UNSET,
        GENERATOR_A,
        GENERATOR_B
    }

    public GameObject coordinatorObject = null;
    public CoordinatedGeneratorID generatorID = CoordinatedGeneratorID.UNSET;

	void Start ()
    {
        // Update() should not be called on this component
        this.enabled = false;

        // check that a valid coordinator GameObject has been specified
        if (this.coordinatorObject != null)
        {
            // get and check that the given coordinator GameObject has the proper coordinator component script
            MutexArrowCoordinator coordinatorComponent = this.coordinatorObject.GetComponent<MutexArrowCoordinator>();
            if(coordinatorComponent != null)
            {
                // ToDo: create our generator instance, to register with the coordinator and to provide to a RhythmCore

                // ToDo: handle the selected generator ID
                switch (this.generatorID)
                {
                    case CoordinatedGeneratorID.GENERATOR_A:
                    {
                        coordinatorComponent.RegisterGeneratorA(null);
                    }
                    break;
                    case CoordinatedGeneratorID.GENERATOR_B:
                    {
                        coordinatorComponent.RegisterGeneratorB(null);
                    }
                    break;
                    case CoordinatedGeneratorID.UNSET:
                    {
                        Debug.LogError("MutexArrowNoRepeatComponent ID left unset - please ensure either A or B are selected as ID");
                    }
                    break;
                    default:
                    {
                        Debug.LogError("Unexpected value for generatorID field of MutexArrowNoRepeatComponent");
                    }
                    break;
                }
            }
            else
            {
                Debug.LogError("Specified GameObject has no MutexArrowCoordinator component - please select a valid coordinator GameObject in the scene");
            }
        }
        else
        {
            Debug.LogError("No coordinator GameObject selected in MutexArrowNoRepeatComponent - please select a coordinator GameObject in the scene");
        }
	}
	
	void Update ()
    {
        Debug.LogError("Update() of MutexArrowNoRepeatComponent called - should not occur.");
	}

    public override ABeatGenerationStrategy GetStrategy()
    {
        // ToDo: Replace this with design-correct code (return our Mutex strategies)
        Debug.Log("HORAY: We have successfully provided a custom beat generation strategy to our RhythmCore!");
        return new RandArrowNoRepeatStrat();
    }
}
