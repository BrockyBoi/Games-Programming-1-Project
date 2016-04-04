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

    protected ResourceController controller;
    protected BuildingController buildingController;

    protected float upgradeTime;
    protected bool isUpgrading;

    // Use this for initialization
    protected void Start () {
        controller = GameObject.Find("Resource Controller").GetComponent<ResourceController>();
        upgradeCanvas = GameObject.Find("Canvases").GetComponent<BuildingUpgradeCanvas>();
        buildingController = GameObject.Find("Building Controller").GetComponent<BuildingController>();

        level = 1;
        upgradeParameters();
        setProduction();

        buildingController.setBuildingLevel(buildingName, level);

        upgradeTime = 15;
    }
	
	// Update is called once per frame
	protected void Update () {
	
	}

    protected void OnMouseDown()
    {
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

            Invoke("upgrade", upgradeTime);
            isUpgrading = true;
        }
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
    {}

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
            "\nStone needed: " + u.rocksNeeded + "\nIron needed: " + u.ironNeeded;
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
