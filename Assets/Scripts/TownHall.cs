using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TownHall : Building {
    public List<GameObject> plotList;

	// Use this for initialization
	new void Start () {
        buildingName = "Town Hall";
        base.Start();
        description = "A town hall is the most vital building of the city.  The only way to get the best structures is a fully leveled Town Hall.";
        production = "";

        DisablePlots(0, 11);
        UnlockPlots(0, 3);
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override void upgrade()
    {
        base.upgrade();

        switch (level)
        {
            case (2):
                UnlockPlots(4, 5);
                break;
            case (3):
                UnlockPlots(6, 7);
                break;
            case (4):
                UnlockPlots(8, 9);
                break;
            case (5):
                UnlockPlots(10, 11);
                break;
            default:
                break;
        }
    }

    protected override bool buildingPrereqs()
    {
        switch(level)
        {
            case 1:
                preReq = makeNeedString("Farm", 2, "Smith", 2) + "\n" + makeNeedString("Forestry", 2, "Quarry", 2);
                if (BuildingController.controller.getFarmLevel() == 2 && BuildingController.controller.getSmithLevel() == 2 && BuildingController.controller.getQuarryLevel() == 2 && BuildingController.controller.getLumberyardLevel() == 2)
                    return true;
                else return false;
            case 2:
                preReq = makeNeedString("Workshop", 2, "Forge", 2);
                if (BuildingController.controller.getWorkshopLevel() == 2 && BuildingController.controller.getForgeLevel() == 2)
                    return true;
                else return false;
            case 3:
                preReq = makeNeedString("Workshop", 3, "Forge", 3);
                if (BuildingController.controller.getWorkshopLevel() == 3 && BuildingController.controller.getForgeLevel() == 3)
                    return true;
                else return false;
            case 4:
                preReq = makeNeedString("Workshop", 4, "Forge", 4);
                if (BuildingController.controller.getWorkshopLevel() == 4 && BuildingController.controller.getForgeLevel() == 4)
                    return true;
                else return false;
            default:
                return true;
        }
    }

    protected override void upgradeParameters()
    {
        //Cap bases are 1500, 5000, 8000, 15000
        //Food, wood, iron, stone
        switch (level)
        {
            case 1:
                setNeeds(500, 1000, 900, 1100);
                break;
            case 2:
                setNeeds(3000, 6000, 5500, 6500);
                break;
            case 3:
                setNeeds(6500, 13000, 12000, 14000);
                break;
            case 4:
                setNeeds(17500, 35000, 30000, 40000);
                break;
            default:
                break;
        }
    }

    void DisablePlots(int from, int to)
    {
        for(int i = from; i <= to; i++)
        {
            plotList[i].gameObject.SetActive(false);
        }
    }

    void UnlockPlots(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            plotList[i].gameObject.SetActive(true);
        }
    }
}
