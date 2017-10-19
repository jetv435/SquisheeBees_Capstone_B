using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -----------------------------------------------------------------------------
// Command
// 
// Description: (from Gang-of-Four) "Encapsulate a request as an object, thereby
//  letting you parameterize clients with different requests, queue or log requ-
//  ests...".
//
//  Depending on the concrete implementation class used, Execute can run
//  almost any code you want. Very useful.
//
// -----------------------------------------------------------------------------

abstract public class Command : ScriptableObject
{
    // Implement this in your concrete class
    abstract public void Execute();
}
