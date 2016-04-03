using UnityEngine;
using System.Collections;

public class Workshop : Building {

	// Use this for initialization
	new void Start () {
        base.Start();
        buildingName = "Workshop";
        description = "Workshops are designed to give the city tools for advanced buildings.  They have no requirements other than a hefty price.";
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    protected override bool buildingPrereqs()
    {
        return true;
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
}
