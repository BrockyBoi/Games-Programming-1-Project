using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Plot : MonoBehaviour {
    ResourceController controller;
    public Canvas buildingList;

    public GameObject farm;
    public GameObject forestry;
    public GameObject mine;
    public GameObject quarry;
    public GameObject barracks;
    public GameObject forge;
    public GameObject workshop;
    public GameObject cottage;
    public GameObject university;

    GameObject setBuilding;
    bool empty;

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
        controller = GameObject.Find("Resource Controller").GetComponent<ResourceController>();
        empty = true;
        buildingList.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if(empty)
            buildingList.gameObject.SetActive(true);
    }

    public bool getEmpty()
    {
        return empty;
    }

    public void setEmpty(bool b)
    {
        empty = b;
    }


    public void build(string s)
    {
        if(s == "Forestry")
        {
            setBuilding = forestry;
            //Food, wood, iron, stone
            b.setNeeds(200, 150, 50, 150);
        }
        if (s == "Farm")
        {
            setBuilding = farm;
            b.setNeeds(50, 200, 50, 150);
        }    
        if (s == "Mine")
        {
            setBuilding = mine;
            b.setNeeds(100, 200, 100, 200);
        }
        if (s == "Quarry")
        {
            setBuilding = quarry;
            b.setNeeds(100, 200, 100, 150);
        }
        if (s == "University")
        {
            setBuilding = university;
            b.setNeeds(300, 250, 150, 250);
        }
        if (s == "Workshop")
        {
            setBuilding = workshop;
            b.setNeeds(250, 250, 300, 300);
        }
        if (s == "Cottage")
        {
            setBuilding = cottage;
            b.setNeeds(150, 150, 150, 150);
        }
        if (s == "Forge")
        {
            setBuilding = forge;
            b.setNeeds(250, 200, 300, 300);
        }

        if (controller.meetsResourceNeeds(b.foodNeed,b.woodNeed,b.ironNeed,b.stoneNeed))
        {
            empty = false;
            Instantiate(setBuilding, transform.position, Quaternion.identity);

            controller.subtractMultiple(b.foodNeed, b.woodNeed, b.ironNeed, b.stoneNeed);

            gameObject.SetActive(false);
        }
    }
}
