using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quarry : Producer {
    // Use this for initialization
    new void Start()
    {
        quarry = true;
        buildingName = "Quarry";
        base.Start();

        description = "Quarries are great ways for mining stones for various buildings";
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
                setNeeds(500, 600, 300, 600);
                break;
            case 2:
                setNeeds(3000, 3500, 2500, 3500);
                break;
            case 3:
                setNeeds(5500, 6000, 4500, 6000);
                break;
            case 4:
                setNeeds(15000, 20000, 12500, 20000);
                break;
            default:
                break;
        }
    }
}
