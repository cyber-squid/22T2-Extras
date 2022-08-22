using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSugar : Action
{
    public AddSugar(GOAPBase gBase)
    {
        this.actionEffect = "Sugar Added";
        this.neededEffect = new string[] { "Got Sugar" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.sugarAdded;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotSugar };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Adding a spoon of sugar to the cup");
        yield return null;
    }
}
