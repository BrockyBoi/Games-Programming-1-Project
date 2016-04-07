using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Army : MonoBehaviour {
    public Text text;

    protected int totalStrength;
    protected int farmerStrength;
    protected int soldierStrength;
    protected int archerStrength;
    protected int cavalryStrength;
    protected int catapultStrength;

    protected bool enemy;

    int forgeStrength;
    float accuracyBoost;

    protected ResourceController controller;
    public struct needs
    {
        public int foodNeed;
        public int woodNeed;
        public int ironNeed;
    }
    public struct farmer
    {
        public int strength;
        public int hitChance;
        public needs need;
        public float recruitTime;
    }
    public farmer f;

    public struct soldier
    {
        public int strength;
        public int hitChance;
        public needs need;
        public float recruitTime;
    }
    public soldier s;

    public struct archer
    {
        public int strength;
        public int hitChance;
        public needs need;
        public float recruitTime;
    }
    public archer a;

    public struct cavalry
    {
        public int strength;
        public int hitChance;
        public needs need;
        public float recruitTime;
    }
    public cavalry cav;

    public struct catapult
    {
        public int strength;
        public int hitChance;
        public needs need;
        public float recruitTime;
    }
    public catapult cat;

	// Use this for initialization
	protected void Start () {
        controller = GameObject.Find("Resource Controller").GetComponent<ResourceController>();

        f.strength = 1;
        f.hitChance = 65 + (int)(65 * accuracyBoost);
        f.need.foodNeed = 50;
        f.need.woodNeed = 50;
        f.need.ironNeed = 15;
        f.recruitTime = 2;

        s.strength = 5;
        s.hitChance = 80 + (int)(80 * accuracyBoost);
        s.need.foodNeed = 150;
        s.need.woodNeed = 25;
        s.need.ironNeed = 150;
        s.recruitTime = 10;

        a.strength = 3;
        a.hitChance = 90 + (int)(90 * accuracyBoost);
        a.need.foodNeed = 150;
        a.need.woodNeed = 250;
        a.need.ironNeed = 50;
        a.recruitTime = 15;

        cav.strength = 10;
        cav.hitChance = 75 + (int)(75 * accuracyBoost);
        cav.need.foodNeed = 750;
        cav.need.woodNeed = 500;
        cav.need.ironNeed = 750;
        cav.recruitTime = 30;

        cat.strength = 50;
        cat.hitChance = 55 + (int)(55 * accuracyBoost);
        cat.need.foodNeed = 500;
        cat.need.woodNeed = 2000;
        cat.need.ironNeed = 2000;
        cat.recruitTime = 60;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = displayArmy();

        f.hitChance = 65 + (int)(65 * accuracyBoost);
        s.hitChance = 80 + (int)(80 * accuracyBoost);
        a.hitChance = 90 + (int)(90 * accuracyBoost);
        cav.hitChance = 75 + (int)(75 * accuracyBoost);
        cat.hitChance = 55 + (int)(55 * accuracyBoost);
    }

    public void setAccuracyBoost(float f)
    {
        accuracyBoost += f;
    }

    public void setForgeStrength(int num)
    {
        if (!enemy)
            forgeStrength = num;
        else forgeStrength = 0;
    }

    public int getTotalStrength()
    {
        totalStrength = getFarmerStrength() + getSoldierStrength() + getArcherStrength() + getCavalryStrength() + getCatapultStrength();
        return totalStrength;
    }

    public int armyCount()
    {
        return farmerCount() + soldierCount() + archerCount() + cavalryCount() + catapultCount();
    }

    public farmer getFarmer()
    {
        return f;
    }

    public int getFarmerStrength()
    {
        return farmerStrength + forgeStrength;
    }

    public void setFarmerSize(int num)
    {
        farmerStrength = f.strength * num;
    }

    public void addFarmer(int num)
    {
        farmerStrength += (f.strength * num);
        getTotalStrength();
    }

    public int farmerCount()
    {
        return farmerStrength;
    }

    public string farmerNeeds()
    {
        return "Food: " + f.need.foodNeed + "\nWood: " + f.need.woodNeed + "\nIron: " + f.need.ironNeed;
    }


    public soldier getSoldier()
    {
        return s;
    }
    public int getSoldierStrength()
    {
        return soldierStrength + forgeStrength;
    }

    public void setSoldierSize(int num)
    {
        soldierStrength = s.strength * num;
    }

    public void addSoldier(int num)
    {
        soldierStrength += (s.strength * num);
        getTotalStrength();
    }

    public int soldierCount()
    {
        return soldierStrength / s.strength;
    }

    public string soldierNeeds()
    {
        return "Food: " + s.need.foodNeed + 
             "\nWood: " + s.need.woodNeed + 
             "\nIron: " + s.need.ironNeed;
    }

    public archer getArcher()
    {
        return a;
    }
    public int getArcherStrength()
    {
        return archerStrength + forgeStrength;
    }

    public void setArcherSize(int num)
    {
        archerStrength = a.strength * num;
    }

    public void addArcher(int num)
    {
        archerStrength += (a.strength * num);
        getTotalStrength();
    }

    public int archerCount()
    {
        return archerStrength / a.strength;
    }

    public string archerNeeds()
    {
        return "Food: " + a.need.foodNeed +
             "\nWood: " + a.need.woodNeed +
             "\nIron: " + a.need.ironNeed;
    }

    public cavalry getCavalry()
    {
        return cav;
    }
    public int getCavalryStrength()
    {
        return cavalryStrength + forgeStrength;
    }

    public void setCavalrySize(int num)
    {
        cavalryStrength = cav.strength * num;
    }

    public void addCavalry(int num)
    {
        cavalryStrength += (cav.strength * num);
        getTotalStrength();
    }

    public int cavalryCount()
    {
        return cavalryStrength / cav.strength;
    }

    public string cavalryNeeds()
    {
        return "Food: " + cav.need.foodNeed +
             "\nWood: " + cav.need.woodNeed +
             "\nIron: " + cav.need.ironNeed;
    }

    public catapult getCatapult()
    {
        return cat;
    }
    public int getCatapultStrength()
    {
        return catapultStrength + forgeStrength;
    }

    public void setCatapultSize(int num)
    {
        catapultStrength = cat.strength * num;
    }

    public void addCatapult(int num)
    {
        catapultStrength += (cat.strength * num);
        getTotalStrength();
    }

    public int catapultCount()
    {
        return cavalryStrength / cat.strength;
    }

    public string catapultNeeds()
    {
        return "Food: " + cat.need.foodNeed +
             "\nWood: " + cat.need.woodNeed +
             "\nIron: " + cat.need.ironNeed;
    }


    public void setArmy(int farm, int sold, int arch, int caval, int catap)
    {
        setFarmerSize(farm);
        setSoldierSize(sold);
        setArcherSize(arch);
        setCavalrySize(caval);
        setCatapultSize(catap);


        totalStrength = farmerStrength + soldierStrength + archerStrength + cavalryStrength + catapultStrength;
    }

    protected string displayArmy()
    {
        return "Farmers: " + farmerCount() + "\nSoldiers: " + soldierCount() + "\nArchers: " + archerCount() + "\nCavalry: " + cavalryCount() + "\nCatapults: " + catapultCount() + "\nTotal strength: " + totalStrength.ToString();
    }


}
