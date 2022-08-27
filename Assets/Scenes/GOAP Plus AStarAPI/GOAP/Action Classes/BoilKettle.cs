using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilKettle : Action
{
    public BoilKettle(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.kettleBoiled;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotWater };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Boiling water for the tea");
        yield return null;
    }
}
