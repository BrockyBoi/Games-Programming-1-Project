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
    public Canvas buildingListTown;
    public Canvas buildingListCity;
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
    void Start()
    {
        closeCanvas();
        barracksCanvasSprite = barracksCanvas.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPoint = new Vector3(mousePos.x, mousePos.y, 81.8f);

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
        if ((barracksCanvasSprite.bounds.Contains(worldPoint) && upgradeCanvas.isActiveAndEnabled) == false &&
             (buildingListCity.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListCity.enabled) == false
            && (buildingListTown.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListTown.enabled) == false ||
            (upgradeCanvas.isActiveAndEnabled || buildingListTown.isActiveAndEnabled || buildingListCity.isActiveAndEnabled) == false)
        {
            selectedPlot = p;

            if (CameraPosition.controller.getPosition() == "Town")
            {
                if (p.tag == "Town Plot")
                    buildingListTown.gameObject.SetActive(true);
            }
            else
            {
                if (p.tag == "City Plot")
                    buildingListCity.gameObject.SetActive(true);
            }
        }
        
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

            fNeeds.text = Army.controller.getNeedsString(0);
            sNeeds.text = Army.controller.getNeedsString(1);
            aNeeds.text = Army.controller.getNeedsString(2);
            cavNeeds.text = Army.controller.getNeedsString(3);
            catNeeds.text = Army.controller.getNeedsString(4);

        }
        else
        {
            upgradeCanvas.gameObject.SetActive(true);
            barracksCanvas.gameObject.SetActive(false);
        }
    }

    public void closeCanvas()
    {
        buildingListTown.gameObject.SetActive(false);
        buildingListCity.gameObject.SetActive(false);
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
