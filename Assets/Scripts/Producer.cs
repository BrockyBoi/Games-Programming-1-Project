﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Producer : Building
{
    protected float produceAmount;
    protected float nextProduceAmount;
    protected int lastResourceCap;
    protected int resourceCap;

    protected bool farm;
    protected bool forestry;
    protected bool quarry;
    protected bool smith;

    // Use this for initialization
    protected new void Start()
    {
        base.Start();
        produceLevel();
        getCap();
        setControllerCap();
        setProduction();

        ResourceController.controller.addResourceRate(buildingName, produceAmount + (produceAmount * ResourceController.controller.getBoost(buildingName)));
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
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
                preReq = makeNeedString("Workshop", 3, "Town Hall", 3);
                if (BuildingController.controller.getWorkshopLevel() == 3 && BuildingController.controller.getTownHallLevel() ==  3)
                    return true;
                else return false;
                    default:
                return false;
        }
    }

    public override void PressDestroy()
    {
        ResourceController.controller.SubtractResourceRate(buildingName, produceAmount);
        RevertControllerCap();
        base.PressDestroy();
    }

    protected override void upgrade()
    {
        base.upgrade();
        produceLevel();
        setControllerCap();
        ResourceController.controller.addResourceRate(buildingName, produceAmount + (produceAmount * ResourceController.controller.getBoost(buildingName)));
    }

    void produceLevel()
    {
        //This is the produce amount every 5 minutes, so I take the base number and divide it by 20 (15 seconds * 4 = one minute, 5 minutes, so 4 * 5)
        switch (level)
        {
            case 1:
                produceAmount = 500.0f / 20.0f;
                nextProduceAmount = 1250.0f / 20.0f;
                break;
            case 2:
                produceAmount = 1250.0f / 20.0f;
                nextProduceAmount = 2500.0f / 20.0f;
                break;
            case 3:
                produceAmount = 2500.0f / 20.0f;
                nextProduceAmount = 5000.0f / 20.0f;
                break;
            case 4:
                produceAmount = 5000.0f / 20.0f;
                nextProduceAmount = 10000.0f / 20.0f;
                break;
            case 5:
                produceAmount = 10000.0f / 20.0f;
                break;
            default:
                break;
        }
    }

    void getCap()
    {
        switch (level)
        {
            case 1:
                lastResourceCap = 0;
                resourceCap = 1500;
                break;
            case 2:
                lastResourceCap = 1500;
                resourceCap = 5000;
                break;
            case 3:
                lastResourceCap = 5000;
                resourceCap = 8000;
                break;
            case 4:
                lastResourceCap = 8000;
                resourceCap = 15000;
                break;
            case 5:
                lastResourceCap = 15000;
                resourceCap = 40000;
                break;
            default:
                break;
        }
    }

    void setControllerCap()
    {
        getCap();

        if (forestry)
            ResourceController.controller.setLogCap(ResourceController.controller.getLogCap() + resourceCap - lastResourceCap);
        else if (smith)
            ResourceController.controller.setIronCap(ResourceController.controller.getIronCap() + resourceCap - lastResourceCap);
        else if (quarry)
            ResourceController.controller.setRockCap(ResourceController.controller.getRockCap() + resourceCap - lastResourceCap);
        else
            ResourceController.controller.setFoodCap(ResourceController.controller.getFoodCap() + resourceCap - lastResourceCap);
    }

    void RevertControllerCap()
    {
        getCap();

        if (forestry)
            ResourceController.controller.setLogCap(ResourceController.controller.getLogCap() - resourceCap);
        else if (smith)
            ResourceController.controller.setIronCap(ResourceController.controller.getIronCap() - resourceCap);
        else if (quarry)
            ResourceController.controller.setRockCap(ResourceController.controller.getRockCap() - resourceCap);
        else
            ResourceController.controller.setFoodCap(ResourceController.controller.getFoodCap() - resourceCap);
    }

    protected override void setProduction()
    {
        if (level < 5)
            production = "Current production: " + (produceAmount * 20).ToString() + "\nNext production: " + (nextProduceAmount * 20).ToString();
        else production = "Current produce amount: " + (produceAmount * 20).ToString();
    }

}