using UnityEngine;
using System.Collections;

public class TownHall : Building {

	// Use this for initialization
	new void Start () {
        buildingName = "Town Hall";
        base.Start();
        description = "A town hall is the most vital building of the city.  The only way to get the best structures is a fully leveled Town Hall";
        production = "";
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override bool buildingPrereqs()
    {
        switch(level)
        {
            case 1:
                if (buildingController.getFarmLevel() == 2 && buildingController.getSmithLevel() == 2 && buildingController.getQuarryLevel() == 2 && buildingController.getLumberyardLevel() == 2)
                    return true;
                else return false;
            case 2:
                if (buildingController.getWorkshopLevel() == 2 && buildingController.getForgeLevel() == 2)
                    return true;
                else return false;
            case 3:
                if (buildingController.getWorkshopLevel() == 3 && buildingController.getForgeLevel() == 3)
                    return true;
                else return false;
            case 4:
                if (buildingController.getWorkshopLevel() == 4 && buildingController.getForgeLevel() == 4)
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
}
