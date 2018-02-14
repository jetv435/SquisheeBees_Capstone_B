using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutexArrowCoordinator : MonoBehaviour
{
	void Start ()
    {
        this.enabled = false;
	}
	
	void Update ()
    {
        Debug.LogError("Update() of MutexArrowCoordinator called - should not occur.");
	}

    public void RegisterGeneratorA(AMutexArrowNoRepeatStrat generator)
    {
        Debug.Log("MutexArrowCoordinator registered its A generator!");
    }

    public void RegisterGeneratorB(AMutexArrowNoRepeatStrat generator)
    {
        Debug.Log("MutexArrowCoordinator registered its B generator!");
    }
}
