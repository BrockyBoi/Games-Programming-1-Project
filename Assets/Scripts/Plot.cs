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
    public bool empty;

    float buildTime;

    struct buildingNeeds
    {
        public int foodNeed;
        public int woodNeed;
        public int ironNeed;
        public int stoneNeed;

        public void setNeeds(int f, int w, int i, int s, Text t)
        {
            foodNeed = f;
            woodNeed = w;
            ironNeed = i;
            stoneNeed = s;

            t.text = "Food: " + f.ToString() + "\nWood: " + w.ToString() + "\nIron: " + i.ToString() + "\nStone: " + s.ToString();
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
        b.setNeeds(200, 150, 50, 150, BuildingUpgradeCanvas.controller.forestryNeeds);
        b.setNeeds(50, 200, 50, 150, BuildingUpgradeCanvas.controller.farmNeeds);
        b.setNeeds(100, 200, 100, 200, BuildingUpgradeCanvas.controller.mineNeeds);
        b.setNeeds(100, 200, 100, 150, BuildingUpgradeCanvas.controller.quarryNeeds);
        b.setNeeds(250, 250, 250, 250, BuildingUpgradeCanvas.controller.barracksNeeds);
        b.setNeeds(300, 250, 150, 250, BuildingUpgradeCanvas.controller.universityNeeds);
        b.setNeeds(250, 250, 300, 300, BuildingUpgradeCanvas.controller.workshopNeeds);
        b.setNeeds(150, 150, 150, 150, BuildingUpgradeCanvas.controller.cottageNeeds);
        b.setNeeds(250, 200, 300, 300, BuildingUpgradeCanvas.controller.forgeNeeds);
    }

    public void build(string s)
    {
        if (s == "Forestry")
        {
            setBuilding = forestry;
            //Food, wood, iron, stone
            b.setNeeds(200, 150, 50, 150,BuildingUpgradeCanvas.controller.forestryNeeds);
            buildTime = 15;
        }
        else if (s == "Farm")
        {
            setBuilding = farm;
            b.setNeeds(50, 200, 50, 150, BuildingUpgradeCanvas.controller.farmNeeds);
            buildTime = 15;
        }
        else if (s == "Mine")
        {
            setBuilding = mine;
            b.setNeeds(100, 200, 100, 200, BuildingUpgradeCanvas.controller.mineNeeds);
            buildTime = 15;
        }
        else if (s == "Quarry")
        {
            setBuilding = quarry;
            b.setNeeds(100, 200, 100, 150, BuildingUpgradeCanvas.controller.quarryNeeds);
            buildTime = 15;
        }
        else if (s == "Barracks")
        {
            setBuilding = barracks;
            b.setNeeds(250, 250, 250, 250, BuildingUpgradeCanvas.controller.barracksNeeds);
            buildTime = 1;
        }
        else if (s == "University")
        {
            setBuilding = university;
            b.setNeeds(300, 250, 150, 250, BuildingUpgradeCanvas.controller.universityNeeds);
            buildTime = 45;
        }
        else if (s == "Workshop")
        {
            setBuilding = workshop;
            b.setNeeds(250, 250, 300, 300, BuildingUpgradeCanvas.controller.workshopNeeds);
            buildTime = 45;
        }
        else if (s == "Cottage")
        {
            setBuilding = cottage;
            b.setNeeds(150, 150, 150, 150, BuildingUpgradeCanvas.controller.cottageNeeds);
            buildTime = 30;
        }
        else if (s == "Forge")
        {
            setBuilding = forge;
            b.setNeeds(250, 200, 300, 300, BuildingUpgradeCanvas.controller.forgeNeeds);
            buildTime = 60;
        }

        if (ResourceController.controller.meetsResourceNeeds(b.foodNeed,b.woodNeed,b.ironNeed,b.stoneNeed) && empty)
        {
            empty = false;

            Invoke("startConstruction", buildTime);
            ResourceController.controller.subtractMultiple(b.foodNeed, b.woodNeed, b.ironNeed, b.stoneNeed);

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


    void startConstruction()
    {
        Instantiate(setBuilding, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
