using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingUpgradeCanvas : MonoBehaviour {
    public Camera cam;
    Vector3 worldPoint, mousePos;
    public static BuildingUpgradeCanvas controller;

    Plot selectedPlot;

    Building currentBuilding;
    Barracks barracksScript;
    University universityScript;

    public Canvas upgradeCanvas;
    public GameObject barracksCanvas;
    public GameObject universityCanvas;
    public Canvas buildingListTown;
    public Canvas buildingListCity;
    public Canvas enemyCanvas;
    public SpriteRenderer barracksCanvasSprite;

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

    public Text invaderText;
    public Text enemyFarmers;
    public Text enemySoldiers;
    public Text enemyArchers;
    public Text enemyCavalry;
    public Text enemyCatapults;
    public Text enemyLevel;
    public Text enemyBonus;

    public Text farmNeeds;
    public Text forestryNeeds;
    public Text mineNeeds;
    public Text quarryNeeds;
    public Text forgeNeeds;
    public Text workshopNeeds;
    public Text universityNeeds;
    public Text barracksNeeds;
    public Text cottageNeeds;

    bool running;
    float upgradeBoost;

    Enemy selectedEnemy;

    public Slider marchSlider;
    public Slider returnSlider;
    void Awake()
    {
        controller = this;
    }

    // Use this for initialization
    void Start()
    {
        closeCanvas();
        //barracksCanvasSprite = barracksCanvas.GetComponentInChildren<SpriteRenderer>();
        marchSlider.gameObject.SetActive(false);
        returnSlider.gameObject.SetActive(false);
        invaderText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
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
        if (canClick())
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

    public Slider accessSlider(int num)
    {
        if (num == 1)
            return marchSlider;
        else return returnSlider;
    }

    public bool canClick()
    {
        if ((upgradeCanvas.isActiveAndEnabled || buildingListTown.isActiveAndEnabled || buildingListCity.isActiveAndEnabled) == false || 
            (barracksCanvasSprite.bounds.Contains(worldPoint) && upgradeCanvas.isActiveAndEnabled) == false && 
            (buildingListCity.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListCity.isActiveAndEnabled) == false
            && (buildingListTown.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListTown.isActiveAndEnabled) == false
            && (enemyCanvas.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && enemyCanvas.isActiveAndEnabled) == false
            && (universityCanvas.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && upgradeCanvas.isActiveAndEnabled) == false) 
            
        {
            return true;
        }
        else return false;
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

        upgradeCanvas.gameObject.SetActive(true);

        if (b.tag == "Barracks")
        {

            universityCanvas.gameObject.SetActive(false);
            barracksScript = b.GetComponent<Barracks>();

            barracksCanvas.gameObject.SetActive(true);

            fNeeds.text = Army.controller.getNeedsString(0);
            sNeeds.text = Army.controller.getNeedsString(1);
            aNeeds.text = Army.controller.getNeedsString(2);
            cavNeeds.text = Army.controller.getNeedsString(3);
            catNeeds.text = Army.controller.getNeedsString(4);
        }
        else if (b.tag == "University")
        {
            barracksCanvas.gameObject.SetActive(false);
            universityScript = b.GetComponent<University>();
            universityCanvas.gameObject.SetActive(true);
        }
        else
        {
            barracksCanvas.gameObject.SetActive(false);
            universityCanvas.gameObject.SetActive(false);
        }
    }

    public void closeCanvas()
    {
        buildingListTown.gameObject.SetActive(false);
        buildingListCity.gameObject.SetActive(false);
        enemyCanvas.gameObject.SetActive(false);
        barracksCanvas.gameObject.SetActive(false);
        upgradeCanvas.gameObject.SetActive(false);
        universityCanvas.gameObject.SetActive(false);
    }

    public void setResearchButton(string s)
    {
        universityScript.setResearch(s);
    }

    public void setUpgradeBoost(float f)
    {
        upgradeBoost += f;
    }

    public float getUpgradeBoost()
    {
        return upgradeBoost;
    }

    public void setInvaderText(float time)
    {
        invaderText.gameObject.SetActive(true);

        invaderText.text = "Incoming barbarians in " + timeCalculation(time);

        if(time < 1)
        {
            invaderText.gameObject.SetActive(false);
        }
    }

    public string timeCalculation(float num)
    {
        int minuteCounter = 0;
        float tempTime = num;
        if (num > 60)
        {
            while (tempTime - 60 > 0)
            {
                tempTime -= 60;
                minuteCounter++;
            }
        }

        return minuteCounter.ToString() + "m " + tempTime.ToString("F0") + "s";
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

    public void pressWorld()
    {
        CameraPosition.controller.setCurrentCam("World");
    }

    public void setEnemy(Enemy e)
    {
        if (canClick())
        {
            enemyCanvas.gameObject.SetActive(true);
            BattleSystem.controller.setEnemy(e);

            selectedEnemy = e;

            updateEnemyStrings();
        }
    }

    public void updateEnemyStrings()
    {

        enemyFarmers.text = "Farmers: " + selectedEnemy.farmerCount().ToString();
        enemySoldiers.text = "Soldiers: " + selectedEnemy.soldierCount().ToString();
        enemyArchers.text = "Archers: " + selectedEnemy.archerCount().ToString();
        enemyCavalry.text = "Cavalry: " + selectedEnemy.cavalryCount().ToString();
        enemyCatapults.text = "Catapult: " + selectedEnemy.catapultCount().ToString();
        enemyLevel.text = "Level: " + selectedEnemy.getLevel();
        if (selectedEnemy.getTotalStrength() > 0)
            enemyBonus.text = "Resource Boost: " + (selectedEnemy.getResourceBoost() * 100).ToString() + "% " + selectedEnemy.getResourceType();
        else enemyBonus.text = "Received Bonus: " + (selectedEnemy.getResourceBoost() * 100).ToString() + "% " + selectedEnemy.getResourceType();
    }
}
