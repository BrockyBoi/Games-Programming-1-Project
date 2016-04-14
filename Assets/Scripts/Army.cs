using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Army : MonoBehaviour {
    public Text text;


    protected int[] troopStrength;
    protected int[] hitChance;

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
        public needs need;
        public float recruitTime;
    }
    public farmer f;

    public struct soldier
    {
        public needs need;
        public float recruitTime;
    }
    public soldier s;

    public struct archer
    {
        public needs need;
        public float recruitTime;
    }
    public archer a;

    public struct cavalry
    {
        public needs need;
        public float recruitTime;
    }
    public cavalry cav;

    public struct catapult
    {
        public needs need;
        public float recruitTime;
    }
    public catapult cat;

	// Use this for initialization
	protected void Start () {
        controller = GameObject.Find("Resource Controller").GetComponent<ResourceController>();
        troopStrength = new int[5]{1,5,3,10,50};
        hitChance = new int[5] { 65 + (int)(65 * accuracyBoost),
                                 80 + (int)(80 * accuracyBoost),
                                 90 + (int)(90 * accuracyBoost),
                                 75 + (int)(75 * accuracyBoost),
                                 55 + (int)(55 * accuracyBoost)};


        f.need.foodNeed = 50;
        f.need.woodNeed = 50;
        f.need.ironNeed = 15;
        f.recruitTime = 2;

        s.need.foodNeed = 150;
        s.need.woodNeed = 25;
        s.need.ironNeed = 150;
        s.recruitTime = 10;

        a.need.foodNeed = 150;
        a.need.woodNeed = 250;
        a.need.ironNeed = 50;
        a.recruitTime = 15;

        cav.need.foodNeed = 750;
        cav.need.woodNeed = 500;
        cav.need.ironNeed = 750;
        cav.recruitTime = 30;

        cat.need.foodNeed = 500;
        cat.need.woodNeed = 2000;
        cat.need.ironNeed = 2000;
        cat.recruitTime = 60;
    }
	
	// Update is called once per frame
	protected void Update () {
        text.text = displayArmy();

        hitChance[0]  = 65 + (int)(65 * accuracyBoost);
        hitChance[1] = 80 + (int)(80 * accuracyBoost);
        hitChance[2] = 90 + (int)(90 * accuracyBoost);
        hitChance[3] = 75 + (int)(75 * accuracyBoost);
        hitChance[4] = 55 + (int)(55 * accuracyBoost);
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
        totalStrength = farmerStrength + soldierStrength + archerStrength + cavalryStrength + catapultStrength;
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
        return troopStrength[0] + forgeStrength;
    }

    public void setFarmerSize(int num)
    {
        farmerStrength = troopStrength[0] * num;
    }

    public void addFarmer(int num)
    {
        farmerStrength += (getFarmerStrength() * num);
        if (farmerStrength < 0)
            farmerStrength = 0;
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
        return troopStrength[1] + forgeStrength;
    }

    public void setSoldierSize(int num)
    {
        soldierStrength = troopStrength[1] * num;
    }

    public void addSoldier(int num)
    {
        soldierStrength += (getSoldierStrength() * num);
        if (soldierStrength < 0)
            soldierStrength = 0;
        getTotalStrength();
    }

    public int soldierCount()
    {
        return soldierStrength / troopStrength[1];
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
        return troopStrength[2] + forgeStrength;
    }

    public void setArcherSize(int num)
    {
        archerStrength = troopStrength[2] * num;
    }

    public void addArcher(int num)
    {
        archerStrength += (getArcherStrength() * num);
        if (archerStrength < 0)
            archerStrength = 0;
        getTotalStrength();
    }

    public int archerCount()
    {
        return archerStrength / troopStrength[2];
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
        return troopStrength[3] + forgeStrength;
    }

    public void setCavalrySize(int num)
    {
        cavalryStrength = troopStrength[3] * num;
    }

    public void addCavalry(int num)
    {
        cavalryStrength += (getCavalryStrength() * num);
        if (cavalryStrength < 0)
            cavalryStrength = 0;
        getTotalStrength();
    }

    public int cavalryCount()
    {
        return cavalryStrength / troopStrength[3];
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
        return troopStrength[4] + forgeStrength;
    }

    public void setCatapultSize(int num)
    {
        catapultStrength = troopStrength[4] * num;
    }

    public void addCatapult(int num)
    {
        catapultStrength += (getCatapultStrength() * num);
        if (catapultStrength < 0)
            catapultStrength = 0;
        getTotalStrength();
    }

    public int catapultCount()
    {
        return catapultStrength / troopStrength[4];
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

    public int getHitChance(int num)
    {
        return hitChance[num];
    }

    protected string displayArmy()
    {
        return "Farmers: " + farmerCount() + "\nSoldiers: " + soldierCount() + "\nArchers: " + archerCount() + "\nCavalry: " + cavalryCount() + "\nCatapults: " + catapultCount() + "\nTotal strength: " + totalStrength.ToString();
    }


}
