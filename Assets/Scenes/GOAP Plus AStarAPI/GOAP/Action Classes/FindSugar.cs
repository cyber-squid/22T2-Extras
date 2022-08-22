using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSugar : Action
{
    public FindSugar(GOAPBase gBase)
    {
        this.actionEffect = "Got Sugar";
        this.neededEffect = new string[] { "Got Cup" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.gotSugar;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotCup };

        percentChanceToFail = 30;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Getting sugar from the sugar jar");
        yield return null;
    }
}
