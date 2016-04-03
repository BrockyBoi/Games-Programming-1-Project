using UnityEngine;
using System.Collections;

public class Forge : Building {
    Army armyController;
	// Use this for initialization
	new void Start () {
        base.Start();
        armyController = GameObject.Find("Army Controller").GetComponent<Army>();
        buildingName = "Forge";
        description = "Forges are great for leveling up your army and making your troops do more damage";
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override void upgrade()
    {
        base.upgrade();
        if(canUpgrade())
        {
            setForgeStrength();
        }
    }

    protected override bool buildingPrereqs()
    {
        switch(level)
        {
            case 1:
                if (buildingController.getQuarryLevel() == 2 && buildingController.getSmithLevel() == 2)
                    return true;
                else return false;
            case 2:
                if (buildingController.getWorkshopLevel() == 2 && buildingController.getTownHallLevel() == 2)
                    return true;
                else return false;
            case 3:
                if (buildingController.getTownHallLevel() == 3 && buildingController.getWorkshopLevel() == 3)
                    return true;
                else return false;
            case 4:
                if (buildingController.getTownHallLevel() == 5 && buildingController.getWorkshopLevel() == 5)
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
                setNeeds(500, 700, 800, 800);
                break;
            case 2:
                setNeeds(3000, 4000, 4500, 4500);
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

    void setForgeStrength()
    {
        switch (level)
        {
            case 1:
                armyController.setForgeStrength(1);
                break;
            case 2:
                armyController.setForgeStrength(3);
                break;
            case 3:
                armyController.setForgeStrength(5);
                break;
            case 4:
                armyController.setForgeStrength(7);
                break;
            case 5:
                armyController.setForgeStrength(10);
                break;
            default:
                break;
        }
    }
}
