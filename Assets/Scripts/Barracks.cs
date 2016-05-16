using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Barracks : Building { 
    float trainingTime;
    float trainingBoost;

    bool soldier;
    bool archer;
    bool cavalry;
    bool catapult;

    bool boughtFarmer;
    float farmerTime;
    int farmerNum;

    bool boughtSoldier;
    float soldierTime;
    int soldierNum;

    bool boughtArcher;
    float archerTime;
    int archerNum;

    bool boughtCavalry;
    float cavalryTime;
    int cavalryNum;

    bool boughtCatapult;
    float catapultTime;
    int catapultNum;

	// Use this for initialization
	new void Start () {
        buildingName = "Barracks";
        base.Start();

        description = "Barracks allow you to enlist troops from your population and add them to the army";
	}
 
	
	// Update is called once per frame
	new void Update () {
        base.Update();

	}

    public void buyFarmer(int num)
    {
        if(ResourceController.controller.meetsResourceNeeds(Army.controller.getTroopNeeds(0).foodNeed,
                                                            Army.controller.getTroopNeeds(0).woodNeed,
                                                            Army.controller.getTroopNeeds(0).ironNeed,
                                                            0)
            && ResourceController.controller.getPopulation() > 0)
        {
            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractMultiple(Army.controller.getTroopNeeds(0).foodNeed,
                                                           Army.controller.getTroopNeeds(0).woodNeed,
                                                           Army.controller.getTroopNeeds(0).ironNeed,
                                                           0);

            farmerNum += num;
            farmerTime += Army.controller.getTroopTime(0);

            if (!boughtFarmer)
            {
                StartCoroutine(farmerTimer());
                boughtFarmer = true;
            }
        }
    }

    IEnumerator farmerTimer()
    {
        BuildingUpgradeCanvas.controller.Activate(BuildingUpgradeCanvas.controller.farmerTime);

        float time = 0;
        while(time < farmerTime)
        {
            time += Time.deltaTime;
            BuildingUpgradeCanvas.controller.farmerTime.text = BuildingUpgradeCanvas.controller.timeCalculation(farmerTime - time);
            yield return null;
        }

        Army.controller.addFarmer(farmerNum);
        boughtFarmer = false;
        farmerNum = 0;
        farmerTime = 0;

        BuildingUpgradeCanvas.controller.Disable(BuildingUpgradeCanvas.controller.farmerTime);
    }

    public void buySoldier(int num)
    {
        if (soldier && ResourceController.controller.meetsResourceNeeds(Army.controller.getTroopNeeds(1).foodNeed,
                                                                        Army.controller.getTroopNeeds(1).woodNeed,
                                                                        Army.controller.getTroopNeeds(1).ironNeed,
                                                                        0)
            &&         ResourceController.controller.getPopulation() > 0)
        {
            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractMultiple(Army.controller.getTroopNeeds(1).foodNeed,
                                                           Army.controller.getTroopNeeds(1).woodNeed,
                                                           Army.controller.getTroopNeeds(1).ironNeed,
                                                           0);

            soldierNum += num;
            soldierTime += Army.controller.getTroopTime(1);

            if (!boughtSoldier)
            {
                StartCoroutine(soldierTimer());
                boughtSoldier = true;   
            }
        }
    }

    IEnumerator soldierTimer()
    {
        BuildingUpgradeCanvas.controller.Activate(BuildingUpgradeCanvas.controller.soldierTime);

        float time = 0;
        while (time < soldierTime)
        {
            time += Time.deltaTime;
            BuildingUpgradeCanvas.controller.soldierTime.text = BuildingUpgradeCanvas.controller.timeCalculation(soldierTime - time);
            yield return null;
        }

        Army.controller.addFarmer(soldierNum);
        boughtSoldier = false;
        soldierNum = 0;
        soldierTime = 0;

        BuildingUpgradeCanvas.controller.Disable(BuildingUpgradeCanvas.controller.soldierTime);
    }

    public void buyArcher(int num)
    {
        if (archer && ResourceController.controller.meetsResourceNeeds( Army.controller.getTroopNeeds(2).foodNeed,
                                                                        Army.controller.getTroopNeeds(2).woodNeed,
                                                                        Army.controller.getTroopNeeds(2).ironNeed,
                                                                        0)
            &&        ResourceController.controller.getPopulation() > 0)
        {
            //armyController.addArcher(num);

            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractMultiple(Army.controller.getTroopNeeds(2).foodNeed,
                                                           Army.controller.getTroopNeeds(2).woodNeed,
                                                           Army.controller.getTroopNeeds(2).ironNeed,
                                                           0);

            archerNum += num;
            archerTime += Army.controller.getTroopTime(2);

            if (!boughtArcher)
            {
                StartCoroutine(archerTimer());
                boughtArcher = true;
            }
        }
    }

    IEnumerator archerTimer()
    {
        BuildingUpgradeCanvas.controller.Activate(BuildingUpgradeCanvas.controller.archerTime);

        float time = 0;
        while (time < archerTime)
        {
            time += Time.deltaTime;
            BuildingUpgradeCanvas.controller.archerTime.text = BuildingUpgradeCanvas.controller.timeCalculation(archerTime - time);
            yield return null;
        }

        Army.controller.addFarmer(archerNum);
        boughtArcher = false;
        archerNum = 0;
        archerTime = 0;

        BuildingUpgradeCanvas.controller.Disable(BuildingUpgradeCanvas.controller.archerTime);
    }

    public void buyCavalry(int num)
    {
        if (cavalry && ResourceController.controller.meetsResourceNeeds(Army.controller.getTroopNeeds(3).foodNeed,
                                                                        Army.controller.getTroopNeeds(3).woodNeed,
                                                                        Army.controller.getTroopNeeds(3).ironNeed,
                                                                        0)
            &&         ResourceController.controller.getPopulation() > 0)
        {
            //armyController.addCavalry(num);

            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractMultiple(Army.controller.getTroopNeeds(3).foodNeed,
                                                           Army.controller.getTroopNeeds(3).woodNeed,
                                                           Army.controller.getTroopNeeds(3).ironNeed,
                                                           0);

            cavalryNum += num;
            cavalryTime += Army.controller.getTroopTime(3);

            if (!boughtCavalry)
            {
                StartCoroutine(cavalryTimer());
                boughtCavalry = true;
            }
        }
    }

    IEnumerator cavalryTimer()
    {

        BuildingUpgradeCanvas.controller.Activate(BuildingUpgradeCanvas.controller.cavalryTime);


        float time = 0;
        while (time < cavalryTime)
        {
            time += Time.deltaTime;
            BuildingUpgradeCanvas.controller.cavalryTime.text = BuildingUpgradeCanvas.controller.timeCalculation(cavalryTime - time);
            yield return null;
        }

        Army.controller.addFarmer(cavalryNum);
        boughtCavalry = false;
        cavalryNum = 0;
        cavalryTime = 0;

        BuildingUpgradeCanvas.controller.Disable(BuildingUpgradeCanvas.controller.cavalryTime);
    }

    public void buyCatapult(int num)
    {
        if (catapult && ResourceController.controller.meetsResourceNeeds(Army.controller.getTroopNeeds(4).foodNeed,
                                                                         Army.controller.getTroopNeeds(4).woodNeed,
                                                                         Army.controller.getTroopNeeds(4).ironNeed,
                                                                        0)
            &&          ResourceController.controller.getPopulation() > 0)
        {
            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractMultiple(Army.controller.getTroopNeeds(4).foodNeed,
                                                           Army.controller.getTroopNeeds(4).woodNeed,
                                                           Army.controller.getTroopNeeds(4).ironNeed,
                                                           0);

            catapultNum += num;
            catapultTime += Army.controller.getTroopTime(4);

            if (!boughtCatapult)
            {
                StartCoroutine(catapultTimer());
                boughtCatapult = true;
            }
        }
    }

    IEnumerator catapultTimer()
    {
        BuildingUpgradeCanvas.controller.Activate(BuildingUpgradeCanvas.controller.catapultTime);

        float time = 0;
        while (time < catapultTime)
        {
            time += Time.deltaTime;
            BuildingUpgradeCanvas.controller.catapultTime.text = BuildingUpgradeCanvas.controller.timeCalculation(catapultTime - time);
            yield return null;
        }

        Army.controller.addFarmer(catapultNum);
        boughtCatapult = false;
        catapultNum = 0;
        catapultTime = 0;

        BuildingUpgradeCanvas.controller.Disable(BuildingUpgradeCanvas.controller.catapultTime);
    }

    protected override void upgrade()
    {
        base.upgrade();
        availableUnits();
    }

    public void addBoost(float f)
    {
        trainingBoost += f;
    }

    void availableUnits()
    {
        switch(level)
        {
            case 2:
                soldier = true;
                break;
            case 3:
                soldier = true;
                archer = true;
                break;
            case 4:
                soldier = true;
                archer = true;
                cavalry = true;
                break;
            case 5:
                soldier = true;
                archer = true;
                cavalry = true;
                catapult = true;
                break;
            default:
                break;
        }
    }

    protected override void setProduction()
    {
        switch(level)
        {
            case 1:
                production = "Troops: Farmer\nNext Troop: Soldier";
                break;
            case 2:
                production = "Troops: Farmer, Soldier\nNext Troop: Archer";
                break;
            case 3:
                production = "Troops: Farmer, Soldier, Archer\nNext Troop: Cavalry";
                break;
            case 4:
                production = "Troops: Farmer, Soldier, Archer, Cavalry\nNext Troop: Catapult";
                break;
            case 5:
                production = "Troops: Farmer, Soldier, Archer, Cavalry, Catapult";
                break;
            default:
                break;
        }
    }

    protected override void upgradeParameters()
    {
        //Cap bases are 1500, 5000, 8000, 15000
        //Food, wood, iron, stone
        switch (level)
        {
            case 1:
                setNeeds(700, 600, 1000, 1000);
                break;
            case 2:
                setNeeds(3000, 2750, 4000, 4000);
                break;
            case 3:
                setNeeds(6500, 5500, 9000, 9000);
                break;
            case 4:
                setNeeds(17500, 15000, 22000, 22000);
                break;
            default:
                break;
        }
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
                preReq = makeNeedString("Forge", 2, "Town Hall", 3);
                if (BuildingController.controller.getForgeLevel() == 2 && BuildingController.controller.getTownHallLevel() == 3)
                    return true;
                else return false;
            default:
                return false;
        }
    }
}
