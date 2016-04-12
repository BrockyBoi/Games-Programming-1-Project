using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Plot : MonoBehaviour {

    BuildingUpgradeCanvas buyBuildingCanvas;

    CameraPosition camera;
    ResourceController controller;

    public Canvas buildingListTown;
    public Canvas buildingListCity;

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

        public void setNeeds(int f, int w, int i, int s)
        {
            foodNeed = f;
            woodNeed = w;
            ironNeed = i;
            stoneNeed = s;
        }
    }
    buildingNeeds b;

	// Use this for initialization
	void Start () {
        buyBuildingCanvas = GameObject.Find("Canvases").GetComponent<BuildingUpgradeCanvas>();
        controller = GameObject.Find("Resource Controller").GetComponent<ResourceController>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraPosition>();
        empty = true;
        buildingListTown.gameObject.SetActive(false);
        buildingListCity.gameObject.SetActive(false);
        getPosition();
        setBuilding = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (empty)
        {
            if (camera.getPosition() == "Town")
            {
                if (tag == "Town Plot")
                    buildingListTown.gameObject.SetActive(true);
            }
            else
            {
                if(tag == "City Plot")
                    buildingListCity.gameObject.SetActive(true);
            }

            buyBuildingCanvas.setPlot(this);
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

    void getPosition()
    {
        if (camera.getPosition() == "Town")
        {
            town = true;
            city = false;
        }
        else
        {
            town = false;
            city = true;
        }
    }

    public void build(string s)
    {
        getPosition();
        Debug.Log("Build: " + s);

        if (s == "Forestry")
        {
            setBuilding = forestry;
            //Food, wood, iron, stone
            b.setNeeds(200, 150, 50, 150);
            buildTime = 15;
        }
        else if (s == "Farm")
        {
            setBuilding = farm;
            b.setNeeds(50, 200, 50, 150);
            buildTime = 15;
        }
        else if (s == "Mine")
        {
            setBuilding = mine;
            b.setNeeds(100, 200, 100, 200);
            buildTime = 15;
        }
        else if (s == "Quarry")
        {
            setBuilding = quarry;
            b.setNeeds(100, 200, 100, 150);
            buildTime = 15;
        }

        else if (s == "Barracks")
        {
            setBuilding = barracks;
            b.setNeeds(250, 250, 250, 250);
            buildTime = 30;
        }
        else if (s == "University")
        {
            setBuilding = university;
            b.setNeeds(300, 250, 150, 250);
            buildTime = 45;
        }
        else if (s == "Workshop")
        {
            setBuilding = workshop;
            b.setNeeds(250, 250, 300, 300);
            buildTime = 45;
        }
        else if (s == "Cottage")
        {
            setBuilding = cottage;
            b.setNeeds(150, 150, 150, 150);
            buildTime = 30;
        }
        else if (s == "Forge")
        {
            setBuilding = forge;
            b.setNeeds(250, 200, 300, 300);
            buildTime = 60;
        }

        if (controller.meetsResourceNeeds(b.foodNeed,b.woodNeed,b.ironNeed,b.stoneNeed) && empty)
        {
            Debug.Log("Started building");
            empty = false;

            Invoke("startConstruction", buildTime);
            controller.subtractMultiple(b.foodNeed, b.woodNeed, b.ironNeed, b.stoneNeed);

            gameObject.SetActive(false);
        }
    }

    public void closeCanvas()
    {
        buildingListTown.gameObject.SetActive(false);
        buildingListCity.gameObject.SetActive(false);
    }

    void startConstruction()
    {
        Instantiate(setBuilding, transform.position, Quaternion.identity);
    }
}
