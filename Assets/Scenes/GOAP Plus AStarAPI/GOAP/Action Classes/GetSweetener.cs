using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSweetener : Action
{
    public GetSweetener(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.gotSugar;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotCup };

        failMessage = "We're out of sweeteners, too!";

        percentChanceToFail = 10;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Using some sweetener instead");
        yield return null;
    }
}
