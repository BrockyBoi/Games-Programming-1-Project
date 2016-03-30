using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Plot : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    ResourceController controller;
    public Canvas buildingList;
    public GameObject forestry;
    bool empty;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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

    

    public void buildForestry()
    {
        if (controller.getFood() >= 100 && controller.getIron() >= 50 && controller.getLogs() >= 250 && controller.getRocks() >= 150)
        {
            empty = false;
            Instantiate(forestry, transform.position, Quaternion.identity);

            controller.subtractFood(100);
            controller.subtractIron(50);
            controller.subtractLogs(250);
            controller.subtractRocks(150);

            gameObject.SetActive(false);
        }
    }
}
