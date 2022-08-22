using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSweetener : Action
{
    public GetSweetener(GOAPBase gBase)
    {
        actionEffect = "Got Sugar";
        neededEffect = new string[] { "Got Cup" };

        prerequisiteToComplete = gBase.listOfPrerequisites.gotSugar;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotCup };

        percentChanceToFail = 10;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Using some sweetener instead");
        yield return null;
    }
}
