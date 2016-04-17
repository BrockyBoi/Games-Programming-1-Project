using UnityEngine;
using System.Collections;

public class Enemy : Army {

    public int farmers;
    public int soldiers;
    public int archers;
    public int horsemen;
    public int catapults;

    public int armyLevel;

    //String should be either "Wood", "Food", "Iron", or "Stone"
    public string resourceType;
    public float resourceBoost;
	// Use this for initialization
	new void Start () {
        enemy = true;
        base.Start();
        setArmy(farmers, soldiers, archers, horsemen, catapults);

	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        if (getTotalStrength() < 1)
        {
            ResourceController.controller.addResourceBoost(resourceType, resourceBoost);
            Destroy(gameObject);
        }

	}
}
