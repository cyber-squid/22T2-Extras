using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTea : Action
{
    public MakeTea(GOAPBase gBase)
    {
        this.actionEffect = "Tea Made";
        this.neededEffect = new string[] { "Kettle Boiled", "Teabag Added", "Sugar Added" };

        this.prerequisiteToComplete = gBase.listOfPrerequisites.teaMade;
        this.givenPrerequisites = new Prerequisite[] { gBase.listOfPrerequisites.kettleBoiled,
                                            gBase.listOfPrerequisites.teabagAdded,
                                            gBase.listOfPrerequisites.sugarAdded };
    }

    protected override IEnumerator PerformAction(GOAPBase gBase)
    {
        Debug.Log("Pouring and stirring the tea");
        yield return null;
    }
}
