using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingUpgradeCanvas : MonoBehaviour {
    Plot selectedPlot;
    CameraPosition camera;

    Building currentBuilding;
    Barracks barracksScript;
    Army armyController;
    Canvas upgradeCanvas;
    GameObject barracksCanvas;
    Text title;
    Text description;
    Text needs;
    Text production;
    Text fNeeds;
    Text sNeeds;
    Text aNeeds;
    Text cavNeeds;
    Text catNeeds;

    bool running;
    float upgradeBoost;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<CameraPosition>();
        armyController = GameObject.Find("Army Controller").GetComponent<Army>();
        upgradeCanvas = GameObject.Find("BuildingDescriptionCanvas").GetComponent<Canvas>();
        barracksCanvas = GameObject.Find("BarracksCanvas");
        title = GameObject.Find("BuildingTitle").GetComponent<Text>();
        description = GameObject.Find("BuildingDescription").GetComponent<Text>();
        production = GameObject.Find("ProductionRates").GetComponent<Text>();
        needs = GameObject.Find("NeedsText").GetComponent<Text>();

        fNeeds = GameObject.Find("Farmer Text").GetComponent<Text>();
        sNeeds = GameObject.Find("Soldier Text").GetComponent<Text>();
        aNeeds = GameObject.Find("Archer Text").GetComponent<Text>();
        cavNeeds = GameObject.Find("Cavalry Text").GetComponent<Text>();
        catNeeds = GameObject.Find("Catapult Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {

        if (running)
        {
            if (currentBuilding.tag == "Barracks")
            {
                barracksCanvas.gameObject.SetActive(true);

                fNeeds.text = armyController.farmerNeeds();
                sNeeds.text = armyController.soldierNeeds();
                aNeeds.text = armyController.archerNeeds();
                cavNeeds.text = armyController.cavalryNeeds();
                catNeeds.text = armyController.catapultNeeds();
            }
            else barracksCanvas.gameObject.SetActive(false);

            upgradeCanvas.gameObject.SetActive(true);
            title.text = currentBuilding.getTitleText();
            description.text = currentBuilding.getDescriptionText();
            production.text = currentBuilding.getProductionText();
            needs.text = currentBuilding.createNeedString();
        }
        else
        {
            upgradeCanvas.gameObject.SetActive(false);
        }
    }

    public void setPlot(Plot p)
    {
        selectedPlot = p;
    }

    public void build(string s)
    {
        selectedPlot.build(s);
    }

    public void setBuilding(Building b)
    {
        currentBuilding = b;
        running = true;
        if (b.tag == "Barracks")
            barracksScript = b.GetComponent<Barracks>();
    }

    public void setUpgradeBoost(float f)
    {
        upgradeBoost += f;
    }

    public float getUpgradeBoost()
    {
        return upgradeBoost;
    }

    public void buyFarmer(int num)
    {
        barracksScript.buyFarmer(num);
    }
    public void buySoldier(int num)
    {
        barracksScript.buySoldier(num);
    }
    public void buyArcher(int num)
    {
        barracksScript.buyArcher(num);
    }
    public void buyCavalry(int num)
    {
        barracksScript.buyCavalry(num);
    }
    public void buyCatapult(int num)
    {
        barracksScript.buyCatapult(num);
    }

    public void hitUpgrade()
    {
        currentBuilding.pressUpgrade();
    }

    public void pressExit()
    {
        running = false;
        currentBuilding = null;
    }

    public void pressTown()
    {
        camera.setCurrentCam("Town");
    }

    public void pressCity()
    {
        camera.setCurrentCam("City");
    }
}
