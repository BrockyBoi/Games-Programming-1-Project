using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResourceController : MonoBehaviour {
    public Text text;

    public static ResourceController controller;

    int food;
    float foodRate;
    float foodBoost;
    int foodCap;

    int logs;
    float logRate;
    float logBoost;
    int logCap;

    int rocks;
    float rockRate;
    float rockBoost;
    int rockCap;

    int iron;
    float ironRate;
    float ironBoost;
    int ironCap;

    int population;
    int populationCap;

    public float productionRate;

    void Awake()
    {
        controller = this;
    }

	// Use this for initialization
	void Start () {
        InvokeRepeating("incrementResources", productionRate, productionRate);
        food = 5000;
        logs = 5000;
        rocks = 5000;
        iron = 5000;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = displayResources();
	}

    public void addFood(float num)
    {
        if(food + num < foodCap)
            food += (int)num;
    }

    public void subtractFood(int num)
    {
        food -= num;
    }

    public int getFood()
    {
        return food;
    }

    public int getFoodCap()
    {
        return foodCap;
    }

    public void setFoodCap(int num)
    {
        foodCap = num;
    }

    public void addLogs(float num)
    {
        if (logs + num < logCap)
        {
            logs += (int)num;
        }
    }

    public void subtractLogs(int num)
    {
        logs -= num;
    }

    public int getLogs()
    {
        return logs;
    }

    public int getLogCap()
    {
        return logCap;
    }

    public void setLogCap(int num)
    {
        logCap = num;
    }

    public void addRocks(float num)
    {
        if(rocks + num < rockCap)
            rocks += (int)num;
    }

    public void subtractRocks(int num)
    {
        rocks -= num;
    }

    public int getRocks()
    {
        return rocks;
    }

    public int getRockCap()
    {
        return rockCap;
    }

    public void setRockCap(int num)
    {
        rockCap = num;
    }

    public void addIron(float num)
    {
        if(iron + num < ironCap)
            iron += (int)num;
    }

    public void subtractIron(int num)
    {
        iron -= num;
    }

    public int getIron()
    {
        return iron;
    }

    public int getIronCap()
    {
        return ironCap;
    }

    public void setIronCap(int num)
    {
        ironCap = num;
    }

    public int getPopulation()
    {
        return population;
    }

    public void addPopulation(int num)
    {
        population += num;
    }

    public void subtractPopulation(int num)
    {
        population -= num;
    }

    string displayResources()
    {
        return "Food: " + food + "\nWood: " + logs + "\nStone: " + rocks + "\nIron: " + iron + "\nPopulation: " + population;
    }

    public void addResourceBoost(string s, float f)
    {
        if (s == "Wood")
            logBoost += f;
        else if (s == "Food")
            foodBoost += f;
        else if (s == "Iron")
            ironBoost += f;
        else
            rockBoost += f;
    }

    public float getBoost(string s)
    {
        if (s == "Forestry")
            return logBoost;
        else if (s == "Farm")
            return foodBoost;
        else if (s == "Mine")
            return ironBoost;
        else
            return rockBoost;
    }

    public bool meetsResourceNeeds(int f, int w, int i, int s)
    {
        if (food >= f && logs >= w && iron >= i && rocks >= s)
            return true;
        else return false;
    }

    public void subtractMultiple(int f, int w, int i, int s)
    {
        subtractFood(f);
        subtractLogs(w);
        subtractIron(i);
        subtractRocks(s);
    }

    public void addResourceRate(string s, float i)
    {
        if(s == "Farm")
        {
            foodRate = i;
        }
        else if(s == "Mine")
        {
            ironRate = i;
        }
        else if(s == "Forestry")
        {
            logRate = i;
        }
        else
        {
            rockRate = i;
        }
    }

    void incrementResources()
    {
        addFood(foodRate);
        addIron(ironRate);
        addLogs(logRate);
        addRocks(rockRate);
    }

        
}
