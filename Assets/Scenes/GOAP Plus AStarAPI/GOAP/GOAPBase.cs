using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAPBase : MonoBehaviour
{
    public PrerequisiteList listOfPrerequisites;
    public ActionList listOfActions;
    Action currentAction;

    bool plottingActions;


    private void Start()
    {
        listOfPrerequisites = new PrerequisiteList();
        listOfActions = new ActionList(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !plottingActions)
        {
            listOfPrerequisites = new PrerequisiteList();
            listOfActions = new ActionList(this); // reset the variables so we plan from the start

            currentAction = new ServeTea(this); // start planning from serve tea
            plottingActions = true;

            //currentAction.TryAction(this);
            if (currentAction.TryAction(this))
            {
                Debug.Log("You got a fresh cup of tea! :)");
            }
            else
                Debug.Log("Sorry, no tea for you :(");
        }
    }
}
