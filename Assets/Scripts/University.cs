using UnityEngine;
using System.Collections;

public class University : Building {
    string researchName;
    string resourceType;
    float resourceBoost;
    float researchTime;

    //Boosts that will go up by 10%
    int farmLevel, mineLevel, quarryLevel, forestryLevel, trainingLevel;
    //Boosts that will go up by 5%
    int accuracyLevel, constructionLevel;
    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    public void setResearch(string s)
    {
        researchName = s;

        if (s == "Farm")
        {
            checkResearchTime(farmLevel);
        }
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

        Invoke("addBoost", researchTime);
    }

    protected override bool buildingPrereqs()
    {
        switch (level)
        {
            case 1:
                return true;
            case 2:
                if (buildingController.getWorkshopLevel() == 2)
                    return true;
                else return false;
            case 3:
                if (buildingController.getTownHallLevel() == 2)
                    return true;
                else return false;
            case 4:
                if (buildingController.getWorkshopLevel() == 3 && buildingController.getTownHallLevel() == 3)
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
                researchTime = 300;
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
        if (researchName == "Farm")
        {
            controller.addResourceBoost(researchName, farmLevel * .1f);
        }
        else if (researchName == "Quarry")
            controller.addResourceBoost(researchName, quarryLevel * .1f);
        else if (researchName == "Mine")
            controller.addResourceBoost(researchName, mineLevel * .1f);
        else if (researchName == "Forestry")
            controller.addResourceBoost(researchName, forestryLevel * .1f);
        else if (researchName == "") ;

    }
}
