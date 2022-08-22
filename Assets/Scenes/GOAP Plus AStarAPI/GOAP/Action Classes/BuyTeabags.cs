using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTeabags : Action
{
    public BuyTeabags(GOAPBase gBase)
    {
        this.actionEffect = "Got Teabag";
        this.neededEffect = new string[] { "None" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.gotTeabag;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.noPrerequisites };

        percentChanceToFail = 20;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Ordering a pack of teabags");
        yield return null;
    }
}
