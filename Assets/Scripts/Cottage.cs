﻿using UnityEngine;
using System.Collections;

public class Cottage : Building {

    int populationLevel;
    int lastPopulationLevel;
    float popRate;
	// Use this for initialization
	new void Start () {
        buildingName = "Cottage";
        base.Start();

        popLevel();
        setControllerPop();
        upgradeParameters();
        popRate = 5;

        InvokeRepeating("addPopulation", popRate, popRate);

        description = "Cottages not only add to your total population, but add to your population based on the level of the cottage.";
        production = "Population added: " + populationLevel.ToString();
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    void addPopulation()
    {
        ResourceController.controller.addPopulation(level);
    }
    void popLevel()
    {
        switch (level)
        {
            case 1:
                populationLevel = 50;
                lastPopulationLevel = 0;
                break;
            case 2:
                populationLevel = 250;
                lastPopulationLevel = 50;
                break;
            case 3:
                populationLevel = 500;
                lastPopulationLevel = 250;
                break;
            case 4:
                populationLevel = 1000;
                lastPopulationLevel = 500;
                break;
            case 5:
                populationLevel = 1750;
                break;
            default:
                break;
        }
        production = "Population added: " + populationLevel.ToString();
    }

    protected override void upgrade()
    {
        base.upgrade();

        setControllerPop();     
    }

    protected override bool buildingPrereqs()
    {
        switch (level)
        {
            case 1:
                return true;
            case 2:
                return true;
            case 3:
                preReq = makeNeedString("Town Hall", 2);
                if (BuildingController.controller.getTownHallLevel() == 2)
                    return true;
                else return false;
            case 4:
                preReq = makeNeedString("Town Hall", 3);
                if (BuildingController.controller.getTownHallLevel() == 3)
                    return true;
                else return false;
            default:
                return false;
        }
    }

    protected override void upgradeParameters()
    {
        //Cap bases are 1500, 5000, 8000, 15000
        //Food, wood, iron, stone
        switch (level)
        {
            case 1:
                setNeeds(500, 550, 300, 550);
                break;
            case 2:
                setNeeds(3000, 4000, 2750, 4000);
                break;
            case 3:
                setNeeds(6500, 7500, 5500, 7500);
                break;
            case 4:
                setNeeds(17500, 20000, 15000, 20000);
                break;
            default:
                break;
        }
    }

    void setControllerPop()
    {
        popLevel();

        ResourceController.controller.setPopCap(populationLevel - lastPopulationLevel + 10);
        ResourceController.controller.addPopulation(populationLevel - lastPopulationLevel);
    }

    public override void PressDestroy()
    {
        popLevel();

        ResourceController.controller.setPopCap(-populationLevel - lastPopulationLevel + 10);
        ResourceController.controller.addPopulation(-populationLevel - lastPopulationLevel);

        base.PressDestroy();
    }
}
