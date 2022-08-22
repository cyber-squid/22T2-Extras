using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTeabag : Action
{
    public AddTeabag(GOAPBase gBase)
    {
        this.actionEffect = "Teabag Added";
        this.neededEffect = new string[] { "Got Teabag", "Got Cup" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.teabagAdded;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.gotTeabag, 
                                                       gBase.listOfPrerequisites.gotTeabag };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Putting a teabag in the cup");
        yield return null;
    }
}
