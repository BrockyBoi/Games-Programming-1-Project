using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingUpgradeCanvas : MonoBehaviour {
    public Camera cam;
    Vector3 mousePos, worldPoint;
    public static BuildingUpgradeCanvas controller;

    Plot selectedPlot;

    Building currentBuilding;
    Barracks barracksScript;

    public Canvas upgradeCanvas;
    public GameObject barracksCanvas;
    SpriteRenderer barracksCanvasSprite;
    public Text title;
    public Text description;
    public Text needs;
    public Text production;
    public Text upgradeTime;
    public Text fNeeds;
    public Text sNeeds;
    public Text aNeeds;
    public Text cavNeeds;
    public Text catNeeds;

    bool running;
    float upgradeBoost;

    void Awake()
    {
        controller = this;
    }

	// Use this for initialization
	void Start () {

        fNeeds.text = Army.controller.farmerNeeds();
        sNeeds.text = Army.controller.soldierNeeds();
        aNeeds.text = Army.controller.archerNeeds();
        cavNeeds.text = Army.controller.cavalryNeeds();
        catNeeds.text = Army.controller.catapultNeeds();

        barracksCanvasSprite = barracksCanvas.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPoint = new Vector3(mousePos.x, mousePos.y, 0);

        if (running)
        {
            title.text = currentBuilding.getTitleText();
            production.text = currentBuilding.getProductionText();
            needs.text = currentBuilding.createNeedString();
            upgradeTime.text = currentBuilding.getUpgradeTimeText();
        }
        else
        {
            upgradeCanvas.gameObject.SetActive(false);
            barracksCanvas.gameObject.SetActive(true);
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

        description.text = currentBuilding.getDescriptionText();

        running = true;

        if (b.tag == "Barracks")
        {
            barracksScript = b.GetComponent<Barracks>();
            barracksCanvas.gameObject.SetActive(true);
        }
        else
        {
            upgradeCanvas.gameObject.SetActive(true);
            barracksCanvas.gameObject.SetActive(false);
        }
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
        CameraPosition.controller.setCurrentCam("Town");
    }

    public void pressCity()
    {
        CameraPosition.controller.setCurrentCam("City");
    }
}
