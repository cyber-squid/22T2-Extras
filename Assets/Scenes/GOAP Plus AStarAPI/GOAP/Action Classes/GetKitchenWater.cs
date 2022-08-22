using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKitchenWater : Action
{
    public GetKitchenWater(GOAPBase gBase)
    {
        this.actionEffect = "Got Water";
        this.neededEffect = new string[] { "Got Cup" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.gotWater;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotCup };

        percentChanceToFail = 30;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Getting water from the kitchen sink");
        yield return null;
    }
}
