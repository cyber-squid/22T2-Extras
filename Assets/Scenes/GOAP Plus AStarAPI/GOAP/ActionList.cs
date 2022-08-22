using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList
{
    public List<Action> possibleActions = new List<Action>();

    ServeTea serveTea;
    MakeTea makeTea;
    BoilKettle boilKettle;
    AddTeabag addTeabag;
    AddSugar addSugar;
    GetKitchenWater getKitchenWater;
    GetBathroomWater getBathroomWater;
    BuyTeabags buyTeabags;
    FindSugar findSugar;
    GetSweetener getSweetener;
    FindCup findCup;

    public ActionList(GOAPBase gBase)
    {
        //List<string> neededEffects = new List<string>();
        //neededEffects.Add("Got Water");
        //string[] neededEffects;// = { "Tea Made" }; 
        //Prerequisite[] givenPrereqs;// = { gBase.listOfPrerequisites.teaMade };


        serveTea = new ServeTea(gBase);
        possibleActions.Add(serveTea);


        makeTea = new MakeTea(gBase);
        possibleActions.Add(makeTea);



        boilKettle = new BoilKettle(gBase);
        possibleActions.Add(boilKettle);


        addTeabag = new AddTeabag(gBase);
        possibleActions.Add(addTeabag);


        addSugar = new AddSugar(gBase);
        possibleActions.Add(addSugar);



        getKitchenWater = new GetKitchenWater(gBase);
        possibleActions.Add(getKitchenWater);

        getBathroomWater = new GetBathroomWater(gBase);
        possibleActions.Add(getBathroomWater);


        buyTeabags = new BuyTeabags(gBase);
        possibleActions.Add(buyTeabags);


        findSugar = new FindSugar(gBase);
        possibleActions.Add(findSugar);

        getSweetener = new GetSweetener(gBase);
        possibleActions.Add(getSweetener);



        findCup = new FindCup(gBase);
        possibleActions.Add(findCup);

    }


}
