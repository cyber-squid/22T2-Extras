using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCup : Action
{
    public FindCup(GOAPBase gBase)
    {
        this.actionEffect = "Got Cup";
        this.neededEffect = new string[] { "None" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.gotCup;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.noPrerequisites };

        percentChanceToFail = 10;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Getting a cup from the cupboard");
        yield return null;
    }
}
