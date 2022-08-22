using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public string actionEffect { get; protected set; } // string corresponding to the prereq this action completes
    public string[] neededEffect { get; protected set; } // strings representing the prereqs this action needs to run

    protected Prerequisite prerequisiteToComplete; 
    protected Prerequisite[] givenPrerequisites;

    public bool hasBeenTried { get; protected set; } // if an action's already been tried and failed, no point trying again

    protected float percentChanceToFail;


    protected string failMessage;
    protected string succeedMessage;

    /*public Action(string actionEffect, string[] neededEffect, Prerequisite PrereqToComplete, Prerequisite[] givenPrereqs)
    {

    }*/


    public virtual bool TryAction(GOAPBase gBase)//, bool[] givenPrerequisites)
    {
        hasBeenTried = true;

        for (int i = 0; i < givenPrerequisites.Length; i++) // check every prereq of this action before executing
        {
            if (!givenPrerequisites[i].hasBeenMet)
            {
                foreach (Action action in gBase.listOfActions.possibleActions) // go through each action in the action list and check viability
                {
                    if (action.actionEffect == neededEffect[i] && !action.hasBeenTried)
                    {
                        if (action.TryAction(gBase)) // if this action successful then the prerequisite is now complete
                        {
                            goto GotPrerequisite; // return to end of the prereq finding loop
                        }
                    }
                }

                //Debug.Log(failMessage);
                return false; // if no prerequisite-getting actions returned successfully, return this function unsucessful

            }

            GotPrerequisite:
                continue;
        }

        if (percentChanceToFail > Random.Range(0, 100)) // give the function a chance to fail even if prerequisites are met
            return false;

        //Debug.Log(succeedMessage);

        gBase.StartCoroutine(PerformAction(gBase)); // do what the action is supposed to do
        prerequisiteToComplete.hasBeenMet = true; // set the prerequisite this completes to true

        return true;
    }

    protected abstract IEnumerator PerformAction(GOAPBase gBase); // the actual actions this class does, eg moving the object or doing calculations

}
