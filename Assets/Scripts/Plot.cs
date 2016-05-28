using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Plot : MonoBehaviour {
    public GameObject farm;
    public GameObject forestry;
    public GameObject mine;
    public GameObject quarry;
    public GameObject barracks;
    public GameObject forge;
    public GameObject workshop;
    public GameObject cottage;
    public GameObject university;

    Button button;

    bool town;
    bool city;

    GameObject setBuilding;
    bool empty;
    bool canBuild;

    float buildTime;

    public Sprite defaultSprite;
    struct buildingNeeds
    {
        public int foodNeed;
        public int woodNeed;
        public int ironNeed;
        public int stoneNeed;

        public void setNeeds(int f, int w, int i, int s, string preReq, Text t)
        {
            foodNeed = f;
            woodNeed = w;
            ironNeed = i;
            stoneNeed = s;

            t.text = "Food: " + f.ToString() + "\nWood: " + w.ToString() + "\nIron: " + i.ToString() + "\nStone: " + s.ToString() + "\nBuilding: " + preReq;
        }

        public void setNeeds(int f, int w, int i, int s)
        {
            foodNeed = f;
            woodNeed = w;
            ironNeed = i;
            stoneNeed = s;
        }
    }
    buildingNeeds b;

    Canvas personalCanvas;
    Slider slider;

    SpriteRenderer spriteRend;
    public Sprite build1;
    public Sprite build2;
    public Sprite build3;

    // Use this for initialization
    void Start () {
        empty = true;
        setBuilding = null;

        setTexts();

        personalCanvas = GetComponentInChildren<Canvas>();
        slider = GetComponentInChildren<Slider>();

        personalCanvas.gameObject.SetActive(false);

        spriteRend = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (empty)
        {
            BuildingUpgradeCanvas.controller.setPlot(this);
        }
    }

    public bool getEmpty()
    {
        return empty;
    }

    public void setEmpty(bool b)
    {
        empty = b;
    }

    void setTexts()
    {
        b.setNeeds(200, 150, 50, 150, "Farm", BuildingUpgradeCanvas.controller.forestryNeeds);
        b.setNeeds(50, 200, 50, 150, "", BuildingUpgradeCanvas.controller.farmNeeds);
        b.setNeeds(100, 200, 100, 200, "Quarry", BuildingUpgradeCanvas.controller.mineNeeds);
        b.setNeeds(100, 200, 100, 150, "Forestry", BuildingUpgradeCanvas.controller.quarryNeeds);
        b.setNeeds(250, 250, 250, 250, "Mine", BuildingUpgradeCanvas.controller.barracksNeeds);
        b.setNeeds(300, 250, 150, 250, "Barracks", BuildingUpgradeCanvas.controller.universityNeeds);
        b.setNeeds(250, 250, 300, 300, "Barracks", BuildingUpgradeCanvas.controller.workshopNeeds);
        b.setNeeds(150, 150, 150, 150, "Mine", BuildingUpgradeCanvas.controller.cottageNeeds);
        b.setNeeds(250, 200, 300, 300, "Workshop", BuildingUpgradeCanvas.controller.forgeNeeds);
    }

    public void build(string s)
    {
        if (s == "Forestry")
        {
            if (BuildingController.controller.getFarmLevel() >= 1)
            {
                setBuilding = forestry;
                //Food, wood, iron, stone
                b.setNeeds(200, 150, 50, 150);
                buildTime = 10;
                canBuild = true;
            }
        }
        else if (s == "Farm")
        {
            setBuilding = farm;
            b.setNeeds(50, 200, 50, 150);
            buildTime = 10;
            canBuild = true;

        }
        else if (s == "Mine")
        {
            if (BuildingController.controller.getQuarryLevel() >= 1)
            {
                setBuilding = mine;
                b.setNeeds(100, 200, 100, 200);
                buildTime = 10;
                canBuild = true;
            }
        }
        else if (s == "Quarry")
        {
            if (BuildingController.controller.getLumberyardLevel() >= 1)
            {
                setBuilding = quarry;
                b.setNeeds(100, 200, 100, 150);
                buildTime = 10;
                canBuild = true;
            }
        }
        else if (s == "Barracks")
        {
            if (BuildingController.controller.getSmithLevel() >= 1)
            {
                setBuilding = barracks;
                b.setNeeds(250, 250, 250, 250);
                buildTime = 30;
                canBuild = true;
            }
        }
        else if (s == "University")
        {
            if (BuildingController.controller.getBarracksLevel() >= 1)
            {
                setBuilding = university;
                b.setNeeds(300, 250, 150, 250);
                buildTime = 45;
                canBuild = true;
            }
        }
        else if (s == "Workshop")
        {
            if (BuildingController.controller.getBarracksLevel() >= 1 && BuildingController.controller.getWorkshopLevel() < 1)
           {
                setBuilding = workshop;
                b.setNeeds(250, 250, 300, 300);
                buildTime = 30;
                canBuild = true;
           }
        }
        else if (s == "Cottage")
        {
            if (BuildingController.controller.getSmithLevel() >= 1)
            {
                setBuilding = cottage;
                b.setNeeds(150, 150, 150, 150);
                buildTime = 20;
                canBuild = true;
            }
        }
        else if (s == "Forge")
        {
            if (BuildingController.controller.getWorkshopLevel() >= 1)
            {
                setBuilding = forge;
                b.setNeeds(250, 200, 300, 300);
                buildTime = 60;
                canBuild = true;
            }
        }

        if (empty && canBuild && ResourceController.controller.meetsResourceNeeds(b.foodNeed,b.woodNeed,b.ironNeed,b.stoneNeed))
        {
            empty = false;
            canBuild = false;

            Invoke("startConstruction", buildTime);
            ResourceController.controller.subtractMultiple(b.foodNeed, b.woodNeed, b.ironNeed, b.stoneNeed);
            ResourceController.controller.updateResourceText();

            BuildingUpgradeCanvas.controller.closeCanvas();

            StartCoroutine(plotTimer());
            SoundController.controller.playTrack("hammer");
        }
    }

    IEnumerator plotTimer()
    {
        float time = 0;
        personalCanvas.gameObject.SetActive(true);
        slider.maxValue = buildTime;
        spriteRend.sprite = build1;

        transform.localScale = new Vector3(12, 12);
        while (time < buildTime)
        {
            time += Time.deltaTime;
            slider.value = time;
            if (time < (buildTime * .66) && time > (buildTime * .33))
                spriteRend.sprite = build2;
            else if (time > buildTime * .66)
                spriteRend.sprite = build3;
            yield return null;
        }

        personalCanvas.gameObject.SetActive(false);
    }

    public void CheckEmpty()
    {
        if (!empty)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            personalCanvas.gameObject.SetActive(false);
            spriteRend.sprite = defaultSprite;
            transform.localScale = new Vector3(50, 50);
        }
    }


    void startConstruction()
    {
        GameObject building = Instantiate(setBuilding, transform.position, Quaternion.identity) as GameObject;
        building.GetComponent<Building>().SetPlot(this);
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        ResourceController.controller.AddMultiple(b.foodNeed, b.woodNeed, b.ironNeed, b.stoneNeed);
        ResourceController.controller.updateResourceText();
        personalCanvas.gameObject.SetActive(false);
        spriteRend.sprite = defaultSprite;
        transform.localScale = new Vector3(50,50);
        empty = true;
    }
}
