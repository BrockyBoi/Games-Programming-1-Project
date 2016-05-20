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

    public Text farmerTime;
    public Text soldierTime;
    public Text archerTime;
    public Text cavalryTime;
    public Text catapultTime;

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

        Disable(marchSlider);
        Disable(returnSlider);
        Disable(invaderText);

        Disable(farmerTime);
        Disable(soldierTime);
        Disable(archerTime);
        Disable(cavalryTime);
        Disable(catapultTime);
    }

    public void Disable(Text t)
    {
        t.gameObject.SetActive(false);
    }

    public void Disable(Canvas t)
    {
        t.gameObject.SetActive(false);
    }

    public void Disable(Slider t)
    {
        t.gameObject.SetActive(false);
    }

    public void Disable(GameObject t)
    {
        t.gameObject.SetActive(false);
    }

    public void Activate(Text t)
    {
        t.gameObject.SetActive(true);
    }

    public void Activate(Canvas t)
    {
        t.gameObject.SetActive(true);
    }

    public void Activate(GameObject t)
    {
        t.gameObject.SetActive(true);
    }

    public void Activate(Slider t)
    {
        t.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPoint = new Vector3(mousePos.x, mousePos.y, mousePos.z);

        if (running)
        {
            title.text = currentBuilding.getTitleText();
            production.text = currentBuilding.getProductionText();
            needs.text = currentBuilding.createNeedString();
            upgradeTime.text = currentBuilding.getUpgradeTimeText();
        }
        else
        {
            Disable(upgradeCanvas);
            Activate(barracksCanvas);
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
                    Activate(buildingListTown);
            }
            else
            {
                if (p.tag == "City Plot")
                    Activate(buildingListCity);
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
        //Debug.Log(upgradeCanvas.isActiveAndEnabled || buildingListTown.isActiveAndEnabled || buildingListCity.isActiveAndEnabled || enemyCanvas.isActiveAndEnabled || upgradeCanvas.isActiveAndEnabled);

        if ((upgradeCanvas.isActiveAndEnabled || buildingListTown.isActiveAndEnabled || buildingListCity.isActiveAndEnabled || enemyCanvas.isActiveAndEnabled || upgradeCanvas.isActiveAndEnabled) == false)
        {
            return true;
        } 
        if(barracksCanvasSprite.bounds.Contains(worldPoint) && upgradeCanvas.isActiveAndEnabled == false)
        {
           if((buildingListCity.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListCity.isActiveAndEnabled) == false)
           {
                if((buildingListTown.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListTown.isActiveAndEnabled) == false)
                {
                    if ((enemyCanvas.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.Contains(worldPoint) && enemyCanvas.isActiveAndEnabled) == false)
                    {
                        if ((universityCanvas.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && upgradeCanvas.isActiveAndEnabled) == false)
                        {
                            return true;
                        }
                    }
                }
           }
        }
        //    && (buildingListCity.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListCity.isActiveAndEnabled) == false
        //    && (buildingListTown.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && buildingListTown.isActiveAndEnabled) == false
        //    && (enemyCanvas.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.Contains(worldPoint) && enemyCanvas.isActiveAndEnabled) == false
        //    && (universityCanvas.GetComponentInChildren<SpriteRenderer>().bounds.Contains(worldPoint) && upgradeCanvas.isActiveAndEnabled) == false) 
            
        //{
        //    return true;
        //}
        return false;
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

        Activate(upgradeCanvas);

        if (b.tag == "Barracks")
        {

            Disable(universityCanvas);
            barracksScript = b.gameObject.GetComponent<Barracks>();

            Activate(barracksCanvas);

            fNeeds.text = Army.controller.getNeedsString(0);
            sNeeds.text = Army.controller.getNeedsString(1);
            aNeeds.text = Army.controller.getNeedsString(2);
            cavNeeds.text = Army.controller.getNeedsString(3);
            catNeeds.text = Army.controller.getNeedsString(4);
        }
        else if (b.tag == "University")
        {
            Disable(barracksCanvas);
            universityScript = b.gameObject.GetComponent<University>();
            Activate(universityCanvas);
        }
        else
        {
            Disable(barracksCanvas);
            Disable(universityCanvas);
        }
    }

    public void closeCanvas()
    {
        Disable(buildingListTown);
        Disable(buildingListCity);
        Disable(enemyCanvas);
        Disable(barracksCanvas);
        Disable(upgradeCanvas);
        Disable(universityCanvas);
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
        Activate(invaderText);
        invaderText.text = "Incoming barbarians in " + timeCalculation(time);

        if(time < 1)
        {
            Disable(invaderText);
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
            Activate(enemyCanvas);
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
