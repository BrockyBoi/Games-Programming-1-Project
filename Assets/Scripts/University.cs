using UnityEngine;
using System.Collections;

public class University : Building {

    string researchName;
    string resourceType;
    float resourceBoost;
    float researchTime;
    bool researching;

    public struct researchNeed
    {
        public int foodNeed;
        public int logNeed;
        public int stoneNeed;
        public int ironNeed;
    }
    public researchNeed r;

    //Boosts that will go up by 10%
    int farmLevel, mineLevel, quarryLevel, forestryLevel, trainingLevel, marchLevel;
    //Boosts that will go up by 5%
    int accuracyLevel, constructionLevel;

    //Boosts that will only go up by 1
    int alarmLevel;

    // Use this for initialization
    new void Start () {
        buildingName = "University";
        description = "Universities allows you to research new technologies to speed up productions";
        base.Start();
        setResearchNeed();

	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override void upgrade()
    {
        base.upgrade();
        setResearchNeed();
    }

    public void setResearch(string s)
    {
        researchName = s;

        if (s == "Farm")
            checkResearchTime(farmLevel);
        else if (s == "Mine")
            checkResearchTime(mineLevel);
        else if (s == "Quarry")
            checkResearchTime(quarryLevel);
        else if (s == "Forestry")
            checkResearchTime(forestryLevel);
        else if (s == "Accuracy")
            checkResearchTime(accuracyLevel);
        else if (s == "Training")
            checkResearchTime(trainingLevel);
        else if (s == "Construction")
            checkResearchTime(constructionLevel);
        else if (s == "Marching")
            checkResearchTime(marchLevel);
        else if (s == "Alarm")
            checkResearchTime(alarmLevel);

        if (ResourceController.controller.meetsResourceNeeds(r.foodNeed, r.logNeed, r.ironNeed, r.stoneNeed) && !researching)
        {
            researching = true;
            ResourceController.controller.subtractMultiple(r.foodNeed, r.logNeed, r.ironNeed, r.stoneNeed);
            Invoke("addBoost", researchTime);
        }
    }
    
    void researchNeeds(int f, int l, int s, int i)
    {
        r.foodNeed = f;
        r.logNeed = l;
        r.stoneNeed = s;
        r.ironNeed = i;
    }

    protected override void upgradeParameters()
    {
        //Cap bases are 1500, 5000, 8000, 15000
        //Food, wood, iron, stone
        switch (level)
        {
            case 1:
                setNeeds(800, 1000, 1200, 1200);
                break;
            case 2:
                setNeeds(3500, 4500, 4500, 4500);
                break;
            case 3:
                setNeeds(6500, 8250, 9500, 9500);
                break;
            case 4:
                setNeeds(17500, 25000, 28000, 28000);
                break;
            default:
                break;
        }
    }

    void setResearchNeed()
    {
        switch (level)
        {
            case 1:
                researchNeeds(1000, 1000, 1000, 1000);
                break;
            case 2:
                researchNeeds(2500, 2500, 2500, 2500);
                break;
            case 3:
                researchNeeds(6000, 6000, 6000, 6000);
                break;
            case 4:
                researchNeeds(12000, 12000, 12000, 12000);
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
                preReq = makeNeedString("Barracks", 2);
                if (BuildingController.controller.getBarracksLevel() == 2)
                    return true;
                else return false;
            case 2:
                preReq = makeNeedString("Workshop", 2);
                if (BuildingController.controller.getWorkshopLevel() == 2)
                    return true;
                else return false;
            case 3:
                preReq = makeNeedString("Town Hall", 3);
                if (BuildingController.controller.getTownHallLevel() == 3)
                    return true;
                else return false;
            case 4:
                preReq = makeNeedString("Workshop", 4, "Town Hall", 4);
                if (BuildingController.controller.getWorkshopLevel() == 4 && BuildingController.controller.getTownHallLevel() == 4)
                    return true;
                else return false;
            default:
                return false;
        }
    }

    void checkResearchTime(int num)
    {
        switch(num)
        {
            case 0:
                researchTime = 90;
                break;
            case 1:
                researchTime = 240;
                break;
            case 2:
                researchTime = 600;
                break;
            case 3:
                researchTime = 900;
                break;
            case 4:
                researchTime = 1800;
                break;
            default:
                break;
        }
    }

    void addBoost()
    {
        if (researchName == "Farm" || researchName == "Quarry" || researchName == "Mine" || researchName == "Forestry")
            ResourceController.controller.addResourceBoost(researchName, .1f);
        else if (researchName == "Training")
            Army.controller.addTrainingBoost(.1f);
        else if (researchName == "Construction")
            BuildingController.controller.addUpgradeBoost(.05f);
        else if (researchName == "Accuracy")
            Army.controller.addAccuracyBoost(.05f);
        else if (researchName == "Marching")
            BattleSystem.controller.addMarchingBoost(.1f);
        else if (researchName == "Alarm")
            Army.controller.addAlarmBoost(1);

        researching = false;

        Debug.Log(researchName + " " + ResourceController.controller.getBoost("Farm"));
    }
}
