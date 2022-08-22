using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequisite
{
    public bool hasBeenMet { get; set; }
}

public class PrerequisiteList
{
    public List<Prerequisite> allPrereqs;
    public Prerequisite noPrerequisites { get; private set; } // for when a function has no prereq

    public Prerequisite teaServed = new Prerequisite(); // our goal effect.

    public Prerequisite teaMade = new Prerequisite();
    public Prerequisite kettleBoiled = new Prerequisite();
    public Prerequisite teabagAdded = new Prerequisite();
    public Prerequisite sugarAdded = new Prerequisite();
    public Prerequisite gotWater = new Prerequisite();
    public Prerequisite gotTeabag = new Prerequisite();
    public Prerequisite gotSugar = new Prerequisite();
    public Prerequisite gotCup = new Prerequisite();

    public PrerequisiteList()
    {
        noPrerequisites = new Prerequisite();
        noPrerequisites.hasBeenMet = true;
        
        allPrereqs = new List<Prerequisite>();
        allPrereqs.Add(noPrerequisites);
        allPrereqs.Add(teaServed);
        allPrereqs.Add(teaMade);
        allPrereqs.Add(kettleBoiled);
        allPrereqs.Add(teabagAdded);
        allPrereqs.Add(sugarAdded);
        allPrereqs.Add(gotWater);
        allPrereqs.Add(gotTeabag);
        allPrereqs.Add(gotSugar);
        allPrereqs.Add(gotCup);

        //
        // how would you be able to set a bunch of variables to a value without specifiying them if you can't use a for loop?
    }

}




