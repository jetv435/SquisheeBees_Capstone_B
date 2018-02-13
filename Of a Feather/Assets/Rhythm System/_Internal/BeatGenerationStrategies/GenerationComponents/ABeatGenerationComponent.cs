// ABeatGenerationComponent
// Garrah E. Johnson - Feb. 2018
//
// Description: If present in the same GameObject as a RhythmCore, this will
//  provide the Rhythm system with an alternative beat generation strategy.
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABeatGenerationComponent : MonoBehaviour
{
    public abstract ABeatGenerationStrategy GetStrategy();
}
