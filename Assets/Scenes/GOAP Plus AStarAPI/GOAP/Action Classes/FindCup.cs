using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCup : Action
{
    public FindCup(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.gotCup;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.noPrerequisites };

        failMessage = "We don't have any cups in the cupboard";

        percentChanceToFail = 10;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Getting a cup from the cupboard");
        yield return null;
    }
}
