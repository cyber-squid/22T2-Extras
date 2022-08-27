using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSugar : Action
{
    public FindSugar(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.gotSugar;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotCup };

        failMessage = "There's no sugar in the jar!";

        percentChanceToFail = 30;
        priorityLevel = 60;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Getting sugar from the sugar jar");
        yield return null;
    }
}
