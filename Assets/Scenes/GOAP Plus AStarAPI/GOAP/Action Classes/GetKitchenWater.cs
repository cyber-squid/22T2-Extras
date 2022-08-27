using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKitchenWater : Action
{
    public GetKitchenWater(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.gotWater;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotCup };

        failMessage = "The sink is out of order!";

        percentChanceToFail = 30;
        priorityLevel = 70;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Getting water from the kitchen sink");
        yield return null;
    }
}
