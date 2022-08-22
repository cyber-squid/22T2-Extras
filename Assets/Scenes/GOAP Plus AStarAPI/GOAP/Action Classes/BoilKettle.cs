using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilKettle : Action
{
    public BoilKettle(GOAPBase gBase)
    {
        this.actionEffect = "Kettle Boiled";
        this.neededEffect = new string[] { "Got Water" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.kettleBoiled;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotWater };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Boiling water for the tea");
        yield return null;
    }
}
