using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTeabags : Action
{
    public BuyTeabags(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.gotTeabag;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.noPrerequisites };

        failMessage = "There's no teabags in stock!";

        percentChanceToFail = 20;
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Ordering a pack of teabags");
        yield return null;
    }
}
