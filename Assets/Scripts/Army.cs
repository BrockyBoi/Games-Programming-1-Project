using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Army : MonoBehaviour {
    public Text text;

    int totalStrength;
    int farmerStrength;
    int soldierStrength;
    int archerStrength;
    int cavalryStrength;
    int catapultStrength;
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
    }
    public farmer f;

    public struct soldier
    {
        public int strength;
        public int hitChance;
        public needs need;
    }
    public soldier s;

    public struct archer
    {
        public int strength;
        public int hitChance;
        public needs need;
    }
    public archer a;

    public struct cavalry
    {
        public int strength;
        public int hitChance;
        public needs need;
    }
    public cavalry cav;

    public struct catapult
    {
        public int strength;
        public int hitChance;
        public needs need;
    }
    public catapult cat;

	// Use this for initialization
	void Start () {
        f.strength = 1;
        f.hitChance = 65;
        f.need.foodNeed = 50;
        f.need.woodNeed = 50;
        f.need.ironNeed = 15;

        s.strength = 5;
        s.hitChance = 80;
        s.need.foodNeed = 150;
        s.need.woodNeed = 25;
        s.need.ironNeed = 150;

        a.strength = 3;
        a.hitChance = 90;
        a.need.foodNeed = 150;
        a.need.woodNeed = 250;
        a.need.ironNeed = 50;

        cav.strength = 10;
        cav.hitChance = 75;
        cav.need.foodNeed = 750;
        cav.need.woodNeed = 500;
        cav.need.ironNeed = 750;

        cat.strength = 50;
        cat.hitChance = 55;
        cat.need.foodNeed = 500;
        cat.need.woodNeed = 2000;
        cat.need.ironNeed = 2000;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = displayArmy();
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
        return farmerStrength;
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


    public soldier getSoldier()
    {
        return s;
    }
    public int getSoldierStrength()
    {
        return soldierStrength;
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


    public archer getArcher()
    {
        return a;
    }
    public int getArcherStrength()
    {
        return archerStrength;
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


    public cavalry getCavalry()
    {
        return cav;
    }
    public int getCavalryStrength()
    {
        return cavalryStrength;
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


    public catapult getCatapult()
    {
        return cat;
    }
    public int getCatapultStrength()
    {
        return catapultStrength;
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

    public void setArmy(int farm, int sold, int arch, int caval, int catap)
    {
        farmerStrength = farm;
        soldierStrength = sold;
        archerStrength = arch;
        cavalryStrength = caval;
        catapultStrength = catap;

        totalStrength = farmerStrength + soldierStrength + archerStrength + cavalryStrength + catapultStrength;
    }

    string displayArmy()
    {
        return "Farmers: " + farmerCount() + "\nSoldiers: " + soldierCount() + "\nArchers: " + archerCount() + "\nCavalry: " + cavalryCount() + "\nCatapults: " + catapultCount() + "\nTotal strength: " + totalStrength.ToString();
    }


}
