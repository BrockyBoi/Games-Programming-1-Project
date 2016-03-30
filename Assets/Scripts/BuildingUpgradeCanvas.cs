using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingUpgradeCanvas : MonoBehaviour {
    Building currentBuilding;
    Canvas upgradeCanvas;
    Text title;
    Text description;
    Text needs;
    Text production;

    bool running;

	// Use this for initialization
	void Start () {
        upgradeCanvas = GameObject.Find("BuildingDescriptionCanvas").GetComponent<Canvas>();
        title = GameObject.Find("BuildingTitle").GetComponent<Text>();
        description = GameObject.Find("BuildingDescription").GetComponent<Text>();
        production = GameObject.Find("ProductionRates").GetComponent<Text>();
        needs = GameObject.Find("NeedsText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        if (running)
        {
            upgradeCanvas.gameObject.SetActive(true);
            title.text = currentBuilding.getTitleText();
            description.text = currentBuilding.getDescriptionText();
            production.text = currentBuilding.getProductionText();
            needs.text = currentBuilding.createNeedString();
        }
        else upgradeCanvas.gameObject.SetActive(false);
    }

    public void setBuilding(Building b)
    {
        currentBuilding = b;
        running = true;
    }

    public void hitUpgrade()
    {
        currentBuilding.upgrade();
    }

    public void pressExit()
    {
        running = false;
        currentBuilding = null;
    }
}
