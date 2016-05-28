using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Building : MonoBehaviour {

    protected string buildingName;
    protected string titleText;
    protected string description;
    protected string production;
    protected string preReq;

    protected int level;
    protected struct NextUpgrade
    {
        public int rocksNeeded;
        public int logsNeeded;
        public int ironNeeded;
        public int foodNeeded;
    }
    protected NextUpgrade u;

    protected float upgradeTime;
    protected float upgradeTimeLeft;
    protected bool isUpgrading;

    protected bool townBuilding;

    protected Plot designatedPlot;

    Canvas personalCanvas;
    Slider slider;

    GameObject parentObject;
    //Text sliderText;
    protected void Awake()
    {
    }

    // Use this for initialization
    protected void Start () {

        level = 1;
        upgradeParameters();
        setProduction();

        BuildingController.controller.setBuildingLevel(buildingName, level);

        setUpdateTime();
        buildingPrereqs();

        personalCanvas = GetComponentInChildren<Canvas>();
        slider = GetComponentInChildren<Slider>();

        personalCanvas.gameObject.SetActive(false);

        transform.SetParent(BuildingController.controller.GetBuildingParent().transform);
    }
	
	// Update is called once per frame
	protected void Update () {

    }

    IEnumerator upgradeTimer()
    {
        activateSlider();
        float time = 0;
        while(time < upgradeTime - .05f)
        {
            time += Time.deltaTime;
            slider.value = time;
            yield return null;
        }

        personalCanvas.gameObject.SetActive(false);
    }

    protected void OnMouseDown()
    {
        if (BuildingUpgradeCanvas.controller.canClick())
        {
            townBuilding = checkBuildingType();
            if (townBuilding && CameraPosition.controller.getPosition() == "Town")
                BuildingUpgradeCanvas.controller.setBuilding(this);
            else if (!townBuilding && CameraPosition.controller.getPosition() == "City")
                BuildingUpgradeCanvas.controller.setBuilding(this);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public string GetName()
    {
        return buildingName;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetParameters(int lev)
    {
        
        if (buildingName != "Town Hall")
        {
            level = lev;
            for (int i = 0; i < lev; i++)
            {
                upgrade();
            }
            float[] minDist = new float[] { 100, 0 };
            GameObject plotList = GameObject.Find("Plots");
            for(int i = 0; i < plotList.transform.childCount; i++)
            {
                float x = plotList.transform.GetChild(i).transform.position.x - transform.position.x;
                float y = plotList.transform.GetChild(i).transform.position.y - transform.position.y;
                float dist = Mathf.Sqrt(x * x + y * y);
                if(dist < minDist[0])
                {
                    minDist[0] = dist;
                    minDist[1] = i;
                }
            }
            designatedPlot = plotList.transform.GetChild((int)minDist[1]).GetComponent<Plot>();
        }
        else
        {
            int newLevel = (lev - level);
            for(int i = 0; i < newLevel; i++)
            {
                upgrade();
            }
        }
    }

    public virtual void PressDestroy()
    {
        designatedPlot.gameObject.SetActive(true);
        designatedPlot.Reset();
        BuildingController.controller.setBuildingLevel(buildingName, 0);
        Destroy(gameObject);
    }

    public void SetPlot(Plot plot)
    {
        designatedPlot = plot;
        Debug.Log(plot.name);
    }

    public void pressUpgrade()
    {
        if (canUpgrade())
        {
            ResourceController.controller.subtractFood(u.foodNeeded);
            ResourceController.controller.subtractIron(u.ironNeeded);
            ResourceController.controller.subtractLogs(u.logsNeeded);
            ResourceController.controller.subtractRocks(u.rocksNeeded);

            setUpdateTime();

            Invoke("upgrade", upgradeTime);

            StartCoroutine(upgradeTimer());
            isUpgrading = true;

            BuildingUpgradeCanvas.controller.closeCanvas();
        }
    }

    void activateSlider()
    {
        personalCanvas.gameObject.SetActive(true);
        slider.maxValue = upgradeTime;
    }


    protected virtual void setUpdateTime()
    {
        switch (level)
        {
            case 1:
                upgradeTime = 15 - (15 * BuildingController.controller.getUpgradeBoost());
                upgradeTimeLeft = upgradeTime;
                break;
            case 2:
                upgradeTime = 45 - (45 * BuildingController.controller.getUpgradeBoost());
                upgradeTimeLeft = upgradeTime;
                break;
            case 3:
                upgradeTime = 120 - (120 * BuildingController.controller.getUpgradeBoost());
                upgradeTimeLeft = upgradeTime;
                break;
            case 4:
                upgradeTime = 300 - (300 * BuildingController.controller.getUpgradeBoost());
                upgradeTimeLeft = upgradeTime;
                break;
        }
    }

    bool checkBuildingType()
    {
        if (buildingName == "Town Hall" || buildingName == "University" || buildingName == "Barracks" || buildingName == "Cottage" || buildingName == "Workshop" || buildingName == "Forge")
        {
            return true;
        }
        else return false;
    }

    protected virtual void upgrade()
    {
        isUpgrading = false;

        level++;

        BuildingController.controller.setBuildingLevel(buildingName, level);

        upgradeParameters();
        setProduction();
        setBuildingTime();
        buildingPrereqs();
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
                upgradeTime = 30 * (1 - BuildingController.controller.getUpgradeBoost());
                break;
            case 2:
                upgradeTime = 90 * (1 - BuildingController.controller.getUpgradeBoost());
                break;
            case 3:
                upgradeTime = 300 * (1 - BuildingController.controller.getUpgradeBoost());
                break;
            case 4:
                upgradeTime = 1500 * (1 - BuildingController.controller.getUpgradeBoost());
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
        return s + "lvl. " + l;
    }

    public string makeNeedString(string s, int l, string s2, int l2)
    {
        return s + " lvl. " + l + "\n" + s2 + " lvl. " + l2;
    }

    protected bool canUpgrade()
    {
        if (ResourceController.controller.meetsResourceNeeds(u.foodNeeded, u.logsNeeded, u.ironNeeded, u.rocksNeeded) &&
            level < 5 && buildingPrereqs() && !isUpgrading)
        {
            return true;
        }
        else return false;
    }

}
