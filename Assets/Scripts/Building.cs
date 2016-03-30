using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Building : MonoBehaviour {
    protected Text needsText;
    protected string buildingName;
    protected string titleText;
    protected string description;
    protected string production;

    BuildingUpgradeCanvas upgradeCanvas;
    protected int level;
    protected struct NextUpgrade
    {
        public int rocksNeeded;
        public int logsNeeded;
        public int ironNeeded;
        public int foodNeeded;
    }
    protected NextUpgrade u;

    protected ResourceController controller;
    // Use this for initialization
    protected void Start () {
        controller = GameObject.Find("Resource Controller").GetComponent<ResourceController>();
        upgradeCanvas = GameObject.Find("Canvases").GetComponent<BuildingUpgradeCanvas>();

        level = 1;
        upgradeParameters();
    }
	
	// Update is called once per frame
	protected void Update () {
	
	}

    protected void OnMouseDown()
    {
        upgradeCanvas.setBuilding(this);
    }

    protected void OnMouseOver()
    {
        //if (level < 5)
        //    text.text = createNeedString();
        //else text.text = "Max level";
    }
    protected void OnMouseExit()
    {
        //needsText.text = "";
    }

    public virtual void upgrade()
    {}
    protected virtual void upgradeParameters()
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
}
