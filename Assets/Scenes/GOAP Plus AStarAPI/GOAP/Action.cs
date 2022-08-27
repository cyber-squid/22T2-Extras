using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : IComparable
{

    protected Prerequisite prerequisiteToComplete; // the condition this action completes
    protected Prerequisite[] givenPrerequisites; // conditions that need to be active for this action to be tried

    public bool hasBeenTried { get; protected set; } // if an action's already been tried and failed, no point trying again

    protected float percentChanceToFail = 0;
    protected float priorityLevel = 50; // how much trying this action should be prioritised over trying others.


    protected string failMessage;
    protected string succeedMessage;

    /*public Action(string actionEffect, string[] neededEffect, Prerequisite PrereqToComplete, Prerequisite[] givenPrereqs)
    {

    }*/


    public virtual bool TryAction(GOAPBase gBase)//, bool[] givenPrerequisites)
    {
        hasBeenTried = true;
        List<Action> viableActions = new List<Action>();

        for (int i = 0; i < givenPrerequisites.Length; i++) // check every prereq of this action before executing
        {
            if (!givenPrerequisites[i].hasBeenMet)
            {
                foreach (Action possibleAction in gBase.listOfActions.possibleActions) // go through each action in the action list and check viability
                {
                    if (possibleAction.prerequisiteToComplete == givenPrerequisites[i] && !possibleAction.hasBeenTried)
                    {
                        viableActions.Add(possibleAction); // add to the list of actions we can take to meet this prereq
                    }
                }

                viableActions.Sort(); // could probably add a randomising factor to priority levels so it doesn't always go for one over another?

                foreach (Action action in viableActions)
                {
                    if (action.TryAction(gBase)) // if this action successful, the prerequisite is now complete
                    {
                        viableActions.Clear(); // empty out the list, don't need these actions anymore

                        goto GotPrerequisite; // return to end of the prereq finding loop
                    }
                }

                //Debug.Log(failMessage);
                return false; // if no prerequisite-getting actions returned successfully, return this function unsucessful

            }

            GotPrerequisite:
                continue;
        }


        if (percentChanceToFail > UnityEngine.Random.Range(0, 100)) // give the function a chance to fail even if prerequisites are met
        {
            Debug.Log(failMessage);
            return false; 
        }     

        //Debug.Log(succeedMessage);

        gBase.StartCoroutine(PerformAction(gBase)); // do what the action is supposed to do
        prerequisiteToComplete.hasBeenMet = true; // set the prerequisite this completes to true

        return true;
    }

    protected abstract IEnumerator PerformAction(GOAPBase gBase); // the actual actions this class does, eg moving the object or doing calculations



    public int CompareTo(object obj)
    {
        Action compareAction = (Action)obj;

        if (compareAction.priorityLevel > this.priorityLevel)
            return 1;

        else if (compareAction.priorityLevel < this.priorityLevel)
            return -1;

        else return 0;

        //return -this.priorityLevel.CompareTo(compareAction.priorityLevel); // if compared object is greater, return lower value to 
    }
}
