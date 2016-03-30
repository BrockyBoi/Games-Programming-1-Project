using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blacksmith : Producer {
    // Use this for initialization
    new void Start()
    {
        smith = true;
        base.Start();

        buildingName = "Mine";
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    protected override void upgradeParameters()
    {
        //Cap bases are 1500, 5000, 8000, 15000
        //Food, wood, iron, stone
        switch (level)
        {
            case 1:
                setNeeds(500, 500, 800, 400);
                break;
            case 2:
                setNeeds(3000, 3000, 4500, 2500);
                break;
            case 3:
                setNeeds(5500, 5500, 8000, 5000);
                break;
            case 4:
                setNeeds(15000, 15000, 22500, 14000);
                break;
            default:
                break;
        }
    }
}
