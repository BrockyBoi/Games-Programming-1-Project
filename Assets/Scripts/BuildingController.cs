﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingController : MonoBehaviour {

    public static BuildingController controller;

    int farmLevel, quarryLevel, smithLevel, lumberyardLevel;
    int townHallLevel, cottageLevel, barracksLevel, forgeLevel, workShopLevel, universityLevel;
    float upgradeBoost;

    public GameObject farm;
    public GameObject forestry;
    public GameObject mine;
    public GameObject quarry;
    public GameObject barracks;
    public GameObject forge;
    public GameObject workshop;
    public GameObject cottage;
    public GameObject university;

    Dictionary<string, GameObject> buildingList;

    public GameObject buildingParentObject;

    void Awake()
    {
        controller = this;

        buildingList = new Dictionary<string, GameObject>();

        buildingList.Add("Farm", farm);
        buildingList.Add("Forestry", forestry);
        buildingList.Add("Mine", mine);
        buildingList.Add("Quarry", quarry);
        buildingList.Add("Barracks", barracks);
        buildingList.Add("Forge", forge);
        buildingList.Add("Workshop", workshop);
        buildingList.Add("Cottage", cottage);
        buildingList.Add("University", university);
    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    public GameObject GetBuildingParent()
    {
        return buildingParentObject;
    }

    public void setBuildingLevel(string s, int num)
    {
        if (s == "Farm")
            setFarmLevel(num);
        if (s == "Mine")
            setSmithLevel(num);
        if (s == "Forestry")
            setLumberyardLevel(num);
        if (s == "University")
            setUniversityLevel(num);
        if (s == "Quarry")
            setQuarryLevel(num);
        if (s == "Barracks")
            setBarracksLevel(num);
        if (s == "Forge")
            setForgeLevel(num);
        if (s == "Workshop")
            setWorkshopLevel(num);
        if (s == "Town Hall")
            setTownHallLevel(num);
    }

    public void SetUpgradeBoost(float f)
    {
        upgradeBoost = f;
    }
    public void addUpgradeBoost(float f)
    {
        upgradeBoost += f;
    }

    public void BuildBuilding(string name, int level, float posX, float posY)
    {
        GameObject building = Instantiate(buildingList[name], new Vector3(posX, posY), Quaternion.identity) as GameObject;
        building.GetComponent<Building>().SetParameters(level);
        Debug.Log("hi");

    }

    public float getUpgradeBoost()
    {
        return upgradeBoost;
    }

    void setFarmLevel(int num)
    {
        if (num > farmLevel)
            farmLevel = num;
    }

    public int getFarmLevel()
    {
        return farmLevel;
    }

    void setQuarryLevel(int num)
    {
        if (num > quarryLevel)
            quarryLevel = num;
    }

    public int getQuarryLevel()
    {
        return quarryLevel;
    }

    void setSmithLevel(int num)
    {
        if (num > smithLevel)
            smithLevel = num;
    }

    public int getSmithLevel()
    {
        return smithLevel;
    }

    void setLumberyardLevel(int num)
    {
        if (num > lumberyardLevel)
            lumberyardLevel = num;
    }

    public int getLumberyardLevel()
    {
        return lumberyardLevel;
    }

    void setCottageLevel(int num)
    {
        if (num > cottageLevel)
            cottageLevel = num;
    }

    public int getCottageLevel()
    {
        return cottageLevel;
    }

    void setBarracksLevel(int num)
    {
        if (num > barracksLevel)
            barracksLevel = num;

        Debug.Log("Barracks Level: " + barracksLevel);
    }

    public int getBarracksLevel()
    {
        return barracksLevel;
    }

    void setTownHallLevel(int num)
    {
        if (num > townHallLevel)
            townHallLevel = num;
    }

    public int getTownHallLevel()
    {
        return townHallLevel;
    }

    void setForgeLevel(int num)
    {
        if (num > forgeLevel)
            forgeLevel = num;
    }

    public int getForgeLevel()
    {
        return forgeLevel;
    }

    void setWorkshopLevel(int num)
    {
        if (num > workShopLevel)
            workShopLevel = num;
    }

    public int getWorkshopLevel()
    {
        return workShopLevel;
    }

    void setUniversityLevel(int num)
    {
        if (num > universityLevel)
            universityLevel = num;
    }
}
