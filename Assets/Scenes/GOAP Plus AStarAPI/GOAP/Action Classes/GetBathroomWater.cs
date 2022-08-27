using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBathroomWater : Action
{
    public GetBathroomWater(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.gotWater;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotCup };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Getting water from the bathroom sink instead (or the toilet?? OAO)");
        yield return null;
    }
}
