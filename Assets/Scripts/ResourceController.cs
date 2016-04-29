using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResourceController : MonoBehaviour {
    public Text foodText;
    public Text woodText;
    public Text stoneText;
    public Text ironText;
    public Text populationText;

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

    int[] limits;
    int[] currentLevels;

    public float productionRate;

    void Awake()
    {
        controller = this;


        limits = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        setLimits(4, 4, 3, 3, 3, 3, 1);
        currentLevels = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    }

	// Use this for initialization
	void Start () {
        InvokeRepeating("incrementResources", productionRate, productionRate);
        food = 5000;
        logs = 5000;
        rocks = 5000;
        iron = 5000;
        population = 10;
        updateResourceText();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void setLimits(int o, int tw, int th, int fo, int fi, int si, int se)
    {
        limits[1] = o;
        limits[2] = tw;
        limits[3] = th;
        limits[4] = fo;
        limits[5] = fi;
        limits[6] = si;
        limits[7] = se;
    }

    public void addedLevel(int num)
    {
        currentLevels[num]++;
    }

    public int getNum(int n)
    {
        return currentLevels[n];
    }

    public bool checkIfCanSet(int num)
    {
        if (currentLevels[num] < limits[num])
            return true;
        else return false;
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
        if(population + num < populationCap)
            population += num;
    }

    public void subtractPopulation(int num)
    {
        population -= num;
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

        updateResourceText();
    }

    public void updateResourceText()
    {
        foodText.text = food.ToString();
        woodText.text = logs.ToString();
        stoneText.text = rocks.ToString();
        ironText.text = iron.ToString();
        populationText.text = population.ToString();
    }


}
