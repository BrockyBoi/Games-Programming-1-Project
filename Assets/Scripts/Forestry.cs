using UnityEngine.UI;
public class Forestry : Producer {
	// Use this for initialization
	new void Start () {
        forestry = true;
        base.Start();

        buildingName = "Forestry";
        description = "Forestries provide wood over time which is primarily used for buildings and some units.";
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
    }

    protected override void upgradeParameters()
    {
        //Cap bases are 1500, 5000, 8000, 15000
        //Food, wood, iron, stone
        switch (level)
        {
            case 1:
                setNeeds(500, 800, 500, 300);
                break;
            case 2:
                setNeeds(3000, 4000, 3000, 2000);
                break;
            case 3:
                setNeeds(6500, 8000, 6000, 5000);
                break;
            case 4:
                setNeeds(17500, 23000, 17500, 15000);
                break;
            default:
                break;
        }
    }
}
