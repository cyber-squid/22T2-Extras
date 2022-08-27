using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeTea : Action
{
    public ServeTea(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.teaServed;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.teaMade };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Serving up the tea made");
        yield return null;
    }
}
