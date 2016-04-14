using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Building : MonoBehaviour {
    protected string buildingName;
    protected string titleText;
    protected string description;
    protected string production;
    protected string preReq;

    protected BuildingUpgradeCanvas upgradeCanvas;
    protected int level;
    protected struct NextUpgrade
    {
        public int rocksNeeded;
        public int logsNeeded;
        public int ironNeeded;
        public int foodNeeded;
    }
    protected NextUpgrade u;
    protected Text needsText;

    protected CameraPosition camera;
    protected ResourceController controller;
    protected BuildingController buildingController;

    protected float upgradeTime;
    protected bool isUpgrading;

    protected bool townBuilding;

    // Use this for initialization
    protected void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<CameraPosition>();
        controller = GameObject.Find("Resource Controller").GetComponent<ResourceController>();
        upgradeCanvas = GameObject.Find("Canvases").GetComponent<BuildingUpgradeCanvas>();
        buildingController = GameObject.Find("Building Controller").GetComponent<BuildingController>();

        level = 1;
        upgradeParameters();
        setProduction();

        buildingController.setBuildingLevel(buildingName, level);

        setUpdateTime();
    }
	
	// Update is called once per frame
	protected void Update () {
	
	}

    protected void OnMouseDown()
    {
        townBuilding = checkBuildingType();
        if(townBuilding && camera.getPosition() == "Town")
            upgradeCanvas.setBuilding(this);
        else if(!townBuilding && camera.getPosition() == "City")
            upgradeCanvas.setBuilding(this);

    }

    public void pressUpgrade()
    {
        if (canUpgrade())
        {
            controller.subtractFood(u.foodNeeded);
            controller.subtractIron(u.ironNeeded);
            controller.subtractLogs(u.logsNeeded);
            controller.subtractRocks(u.rocksNeeded);

            setUpdateTime();
            Invoke("upgrade", upgradeTime);
            isUpgrading = true;
        }
    }


    protected virtual void setUpdateTime()
    {
        switch(level)
        {
            case 1:
                upgradeTime = 15 - (15 * buildingController.getUpgradeBoost());
                break;
            case 2:
                upgradeTime = 45 - (45 * buildingController.getUpgradeBoost()); ;
                break;
            case 3:
                upgradeTime = 120 - (120 * buildingController.getUpgradeBoost()); ;
                break;
            case 4:
                upgradeTime = 300 - (300 * buildingController.getUpgradeBoost()); ;
                break;
        }
    }

    bool checkBuildingType()
    {
        if (buildingName == "Town Hall" || buildingName == "University" || buildingName == "Barracks" || buildingName == "Cottage" || buildingName == "Workshop")
        {
            return true;
        }
        else return false;
    }

    protected virtual void upgrade()
    {
        isUpgrading = false;

        level++;

        buildingController.setBuildingLevel(buildingName, level);

        upgradeParameters();
        setProduction();
        setBuildingTime();
    }

    protected virtual void setProduction()
    {}
    protected virtual void upgradeParameters()
    {}
    protected virtual bool buildingPrereqs()
    {return false;}

    protected virtual void setBuildingTime()
    {
        switch(level)
        {
            case 1:
                upgradeTime = 30 * (1 - buildingController.getUpgradeBoost());
                break;
            case 2:
                upgradeTime = 90 * (1 - buildingController.getUpgradeBoost());
                break;
            case 3:
                upgradeTime = 300 * (1 - buildingController.getUpgradeBoost());
                break;
            case 4:
                upgradeTime = 1500 * (1 - buildingController.getUpgradeBoost());
                break;
            default:
                break;
        }
    }


    public string getTitleText()
    {
        return buildingName + " Lvl. " + level.ToString();
    }

    public string getDescriptionText()
    {
        return description;
    }

    public string getProductionText()
    {
        return production;
    }

    public string getUpgradeTimeText()
    {
        return "Upgrade Time: " + upgradeTime.ToString();
    }

    protected void setNeeds(int food, int logs, int rocks, int iron)
    {
        u.foodNeeded = food;
        u.logsNeeded = logs;
        u.rocksNeeded = rocks;
        u.ironNeeded = iron;
    }

    public string createNeedString()
    {
        return "Food needed : " + u.foodNeeded + "\nWood needed: " + u.logsNeeded +
            "\nStone needed: " + u.rocksNeeded + "\nIron needed: " + u.ironNeeded +
            "\nBuildings: " + preReq;
    }

    public string makeNeedString(string s, int l)
    {
        return "s " + "lvl. " + l;
    }

    public string makeNeedString(string s, int l, string s2, int l2)
    {
        return s + " lvl. " + l + "\n" + s2 + " lvl. " + l2;
    }

    protected bool canUpgrade()
    {
        if (controller.meetsResourceNeeds(u.foodNeeded, u.logsNeeded, u.ironNeeded, u.rocksNeeded) &&
            level < 5 && buildingPrereqs() && !isUpgrading)
        {
            return true;
        }
        else return false;
    }

}
