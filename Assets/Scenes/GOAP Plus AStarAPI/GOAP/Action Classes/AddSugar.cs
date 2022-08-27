using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSugar : Action
{
    public AddSugar(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.sugarAdded;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotSugar };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Adding a spoon of sugar to the cup");
        yield return null;
    }
}
