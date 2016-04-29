using UnityEngine;
using System.Collections;

public class Enemy : Army {
    public Sprite[] farmSprites;
    public Sprite[] forestSprites;
    public Sprite[] mountainSprites;
    public Sprite[] desertSprites;
    SpriteRenderer sR;

    int armyLevel;

    //String should be either "Wood", "Food", "Iron", or "Stone"
    string resourceType;
    float resourceBoost;
	// Use this for initialization
	new void Start () {
        enemy = true;
        base.Start();
        sR = gameObject.GetComponent<SpriteRenderer>();

        int randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            resourceType = "Food";
            sR.sprite = farmSprites[Random.Range(0, farmSprites.Length - 1)];
        }
        else if (randNum == 1)
        {
            resourceType = "Wood";
            sR.sprite = forestSprites[Random.Range(0, forestSprites.Length - 1)];
        }
        else if (randNum == 2)
        {
            resourceType = "Iron";
            sR.sprite = mountainSprites[Random.Range(0, mountainSprites.Length - 1)];
        }
        else
        {
            resourceType = "Stone";
            sR.sprite = desertSprites[Random.Range(0, desertSprites.Length - 1)];
        }

        while (armyLevel == 0)
        {
            int num = (int)Random.Range(1, 7.9f);
            if (ResourceController.controller.checkIfCanSet(num))
            {
                armyLevel = num;
                ResourceController.controller.addedLevel(num);
            }
        }

        switch (armyLevel)
        {
            case (1):
                setArmy(25, 10, 0, 0, 0);
                resourceBoost = .05f;
                break;
            case (2):
                setArmy(150, 50, 50, 0, 0);
                resourceBoost = .08f;
                break;
            case (3):
                setArmy(500, 200, 150, 50, 0);
                resourceBoost = .11f;
                break;
            case (4):
                setArmy(750, 500, 400, 200, 5);
                resourceBoost = .15f;
                break;
            case (5):
                setArmy(1500, 1000, 800, 500, 50);
                resourceBoost = .20f;
                break;
            case (6):
                setArmy(5000, 4000, 3000, 1500, 500);
                resourceBoost = .33f;
                break;
            case (7):
                setArmy(9999, 9999, 9999, 9999, 9999);
                resourceBoost = .5f;
                break;
            default:
                setArmy(0, 0, 0, 0, 0);
                resourceBoost = 0;
                break;
        }

        //Debug.Log("Level: " + armyLevel + " Resource Type: " + resourceType);
	}

	// Update is called once per frame
	new void Update () {
        base.Update();
        if (getTotalStrength() < 1)
        {
            ResourceController.controller.addResourceBoost(resourceType, resourceBoost);
            enabled = false; 
        }
	}

    void OnMouseDown()
    {
        BuildingUpgradeCanvas.controller.setEnemy(this);
    }

    public int getLevel()
    {
        return armyLevel;
    }

    public float getResourceBoost()
    {
        return resourceBoost;
    }

    public string getResourceType()
    {
        return resourceType;
    }


}
