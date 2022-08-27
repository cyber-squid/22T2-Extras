using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTeabag : Action
{
    public AddTeabag(GOAPBase gBase)
    {
        prerequisiteToComplete = gBase.listOfPrerequisites.teabagAdded;
        givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotTeabag, 
                                                       gBase.listOfPrerequisites.gotCup };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Putting a teabag in the cup");
        yield return null;
    }
}
