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
    float currentFarmerTime;
    float farmerTime;
    int farmerNum;

    bool boughtSoldier;
    float currentSoldierTime;
    float soldierTime;
    int soldierNum;

    bool boughtArcher;
    float currentArcherTime;
    float archerTime;
    int archerNum;

    bool boughtCavalry;
    float currentCavalryTime;
    float cavalryTime;
    int cavalryNum;

    bool boughtCatapult;
    float currentCatapultTime;
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

        checkFarmer();
        checkSoldier();
        checkArcher();
        checkCavalry();
        checkCatapult(); 
	}

    public void buyFarmer(int num)
    {
        if(ResourceController.controller.meetsResourceNeeds(Army.controller.f.need.foodNeed * num,
                                         Army.controller.f.need.woodNeed * num,
                                         Army.controller.f.need.ironNeed * num, 0)
            && ResourceController.controller.getPopulation() > 0)
        {
            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractFood(Army.controller.f.need.foodNeed * num);
            ResourceController.controller.subtractIron(Army.controller.f.need.ironNeed * num);
            ResourceController.controller.subtractLogs(Army.controller.f.need.woodNeed * num);

            farmerNum += num;
            farmerTime += Army.controller.f.recruitTime;

            if (boughtFarmer == false)
            {
                currentFarmerTime = Time.time;
                boughtFarmer = true; 
                farmerTime += currentFarmerTime;
            }
        }
    }

    void checkFarmer()
    {
        if (boughtFarmer == true)
        {
            if (Time.time >= farmerTime)
            {
                Army.controller.addFarmer(farmerNum);
                boughtFarmer = false;
                farmerNum = 0;
                farmerTime = 0;
            }
        }
    }

    public void buySoldier(int num)
    {
        if (soldier && ResourceController.controller.getFood() >= Army.controller.s.need.foodNeed * num
            &&         ResourceController.controller.getLogs() >= Army.controller.s.need.woodNeed * num
            &&         ResourceController.controller.getIron() >= Army.controller.s.need.ironNeed * num
            &&         ResourceController.controller.getPopulation() > 0)
        {
            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractFood(Army.controller.s.need.foodNeed * num);
            ResourceController.controller.subtractIron(Army.controller.s.need.ironNeed * num);
            ResourceController.controller.subtractLogs(Army.controller.s.need.woodNeed * num);

            soldierNum += num;
            soldierTime += Army.controller.s.recruitTime;

            if (boughtSoldier == false)
            {
                currentSoldierTime = Time.time;
                boughtSoldier = true;
                soldierTime += currentSoldierTime;
            }
        }
    }

    void checkSoldier()
    {
        if (boughtSoldier == true)
        {
            if (Time.time >= soldierTime)
            {
                Army.controller.addSoldier(soldierNum);
                boughtSoldier = false;
                soldierNum = 0;
                soldierTime = 0;
            }
        }
    }

    public void buyArcher(int num)
    {
        if (archer && ResourceController.controller.getFood() >= Army.controller.a.need.foodNeed * num
            &&        ResourceController.controller.getLogs() >= Army.controller.a.need.woodNeed * num
            &&        ResourceController.controller.getIron() >= Army.controller.a.need.ironNeed * num
            &&        ResourceController.controller.getPopulation() > 0)
        {
            //armyController.addArcher(num);

            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractFood(Army.controller.a.need.foodNeed * num);
            ResourceController.controller.subtractIron(Army.controller.a.need.ironNeed * num);
            ResourceController.controller.subtractLogs(Army.controller.a.need.woodNeed * num);

            archerNum += num;
            archerTime += Army.controller.a.recruitTime;

            if (boughtArcher == false)
            {
                currentArcherTime = Time.time;
                boughtArcher = true;
                archerTime += currentArcherTime;
            }
        }
    }

    void checkArcher()
    {
        if (boughtArcher == true)
        {
            if (Time.time >= archerTime)
            {
                Army.controller.addArcher(archerNum);
                boughtArcher = false;
                archerNum = 0;
                archerTime = 0;
            }
        }
    }

    public void buyCavalry(int num)
    {
        if (cavalry && ResourceController.controller.getFood() >= Army.controller.cav.need.foodNeed * num
            &&         ResourceController.controller.getLogs() >= Army.controller.cav.need.woodNeed * num
            &&         ResourceController.controller.getIron() >= Army.controller.cav.need.ironNeed * num
            &&         ResourceController.controller.getPopulation() > 0)
        {
            //armyController.addCavalry(num);

            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractFood(Army.controller.cav.need.foodNeed * num);
            ResourceController.controller.subtractIron(Army.controller.cav.need.ironNeed * num);
            ResourceController.controller.subtractLogs(Army.controller.cav.need.woodNeed * num);

            cavalryNum += num;
            cavalryTime += Army.controller.cav.recruitTime;

            if (boughtCavalry == false)
            {
                cavalryTime = Time.time;
                boughtCavalry = true;
                cavalryTime += currentCavalryTime;
            }
        }
    }

    void checkCavalry()
    {
        if (boughtCavalry == true)
        {
            if (Time.time >= cavalryTime)
            {
                Army.controller.addCavalry(cavalryNum);
                boughtCavalry = false;
                cavalryNum = 0;
                cavalryTime = 0;
            }
        }
    }

    public void buyCatapult(int num)
    {
        if (catapult && ResourceController.controller.getFood() >= Army.controller.cat.need.foodNeed * num
            &&          ResourceController.controller.getLogs() >= Army.controller.cat.need.woodNeed * num
            &&          ResourceController.controller.getIron() >= Army.controller.cat.need.ironNeed * num
            &&          ResourceController.controller.getPopulation() > 0)
        {
            //armyController.addCatapult(num);

            ResourceController.controller.subtractPopulation(num);
            ResourceController.controller.subtractFood(Army.controller.cat.need.foodNeed * num);
            ResourceController.controller.subtractIron(Army.controller.cat.need.ironNeed * num);
            ResourceController.controller.subtractLogs(Army.controller.cat.need.woodNeed * num);

            catapultNum += num;
            catapultTime += Army.controller.cat.recruitTime;

            if (boughtCatapult == false)
            {
                currentCatapultTime = Time.time;
                boughtCatapult = true;
                catapultTime += currentCatapultTime;
            }
        }
    }

    void checkCatapult()
    {
        if (boughtCatapult == true)
        {
            if (Time.time >= catapultTime)
            {
                Army.controller.addCatapult(catapultNum);
                boughtCatapult = false;
                catapultNum = 0;
                catapultTime = 0;
            }
        }
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
                if (BuildingController.controller.getTownHallLevel() == 2)
                    return true;
                else return false;
            case 4:
                if (BuildingController.controller.getForgeLevel() == 2 && BuildingController.controller.getTownHallLevel() == 3)
                    return true;
                else return false;
            default:
                return false;
        }
    }
}
