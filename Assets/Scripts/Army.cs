using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Army : MonoBehaviour {
    public Text farmerText;
    public Text soldierText;
    public Text archerText;
    public Text cavalryText;
    public Text catapultText;

    public static Army controller;

    protected int[] troopStrength;
    protected int[] hitChance;
    protected float[] recruitTime;

    protected int totalStrength;
    protected int farmerStrength;
    protected int soldierStrength;
    protected int archerStrength;
    protected int cavalryStrength;
    protected int catapultStrength;

    protected bool enemy;

    int forgeStrength;
    float accuracyBoost;
    float trainingBoost;

    public struct needs
    {
        public needs(int f, int w, int i)
        {
            foodNeed = f;
            woodNeed = w;
            ironNeed = i;
        }
        public int foodNeed;
        public int woodNeed;
        public int ironNeed;
        public void setNeeds(int f, int w, int i)
        {
            foodNeed = f;
            woodNeed = w;
            ironNeed = i;
        }
        public bool meetsNeeds(int f, int w, int i)
        {
            if (ResourceController.controller.getFood() >= f && ResourceController.controller.getLogs() >= w && ResourceController.controller.getIron() >= i)
                return true;
            else return false;
        }
    }
    needs f, s, a, cav, cat;

    protected needs[] troopNeeds;

    void Awake()
    {
        controller = this;
    }

    // Use this for initialization
    protected void Start()
    {
        troopStrength = new int[5] { 1, 5, 3, 10, 50 };
        hitChance = new int[5] { 65, 80, 90, 75, 55 };
        recruitTime = new float[5] { 2, 10, 15, 30, 60 };

        f =  new needs(50, 50, 15);
        s = new needs(150,25,150);
        a = new needs(150,250,50);
        cav = new needs(750,500,750);
        cat = new needs(500,200,200);
        troopNeeds = new needs[5] { f,s,a,cav,cat};

        updateArmyStrings();

        setArmy(100, 100, 100, 0, 0);
    }
	
	// Update is called once per frame
	protected void Update () {

    }

    public void addAccuracyBoost(float f)
    {
        accuracyBoost += f;

        hitChance[0] = 65 + (int)(65 * accuracyBoost);
        hitChance[1] = 80 + (int)(80 * accuracyBoost);
        hitChance[2] = 90 + (int)(90 * accuracyBoost);
        hitChance[3] = 75 + (int)(75 * accuracyBoost);
        hitChance[4] = 55 + (int)(55 * accuracyBoost);
    }

    public void addTrainingBoost(float f)
    {
        trainingBoost += f;

        recruitTime[0] -= recruitTime[0] * trainingBoost;
        recruitTime[1] -= recruitTime[1] * trainingBoost;
        recruitTime[2] -= recruitTime[2] * trainingBoost;
        recruitTime[3] -= recruitTime[3] * trainingBoost;
        recruitTime[4] -= recruitTime[4] * trainingBoost;
    }

    public void addAlarmBoost(float f)
    {

    }


    public void setForgeStrength(int num)
    {
        int oldForgeStrength = forgeStrength;
        if (!enemy)
            forgeStrength = num;
        else forgeStrength = 0;

        troopStrength[0] += (forgeStrength - oldForgeStrength);
        troopStrength[1] += (forgeStrength - oldForgeStrength);
        troopStrength[2] += (forgeStrength - oldForgeStrength);
        troopStrength[3] += (forgeStrength - oldForgeStrength);
        troopStrength[4] += (forgeStrength - oldForgeStrength);
    }

    public int getForgeStrength()
    {
        return forgeStrength;
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

    public int getTroopStrength(int num)
    {
        return troopStrength[num];
    }

    public needs getTroopNeeds(int num)
    {
        return troopNeeds[num];
    }

    public float getTroopTime(int num)
    {
        return recruitTime[num];
    }

    public void setTroopSize(int num)
    {

    }

    public void setFarmerSize(int num)
    {
        farmerStrength = troopStrength[0] * num;
    }

    public void addFarmer(int num)
    {
        farmerStrength += (getTroopStrength(0) * num);
        if (farmerStrength < 0)
            farmerStrength = 0;
        getTotalStrength();
        updateArmyStrings();
    }

    public int farmerCount()
    {
        return farmerStrength;
    }

    public void setSoldierSize(int num)
    {
        soldierStrength = troopStrength[1] * num;
    }

    public void addSoldier(int num)
    {
        soldierStrength += (getTroopStrength(1) * num);
        if (soldierStrength < 0)
            soldierStrength = 0;
        getTotalStrength();
        updateArmyStrings();
    }

    public int soldierCount()
    {
        return soldierStrength / troopStrength[1];
    }


    public void setArcherSize(int num)
    {
        archerStrength = troopStrength[2] * num;
    }

    public void addArcher(int num)
    {
        archerStrength += (getTroopStrength(2) * num);
        if (archerStrength < 0)
            archerStrength = 0;
        getTotalStrength();
        updateArmyStrings();
    }

    public int archerCount()
    {
        return archerStrength / troopStrength[2];
    }


    public void setCavalrySize(int num)
    {
        cavalryStrength = troopStrength[3] * num;
    }

    public void addCavalry(int num)
    {
        cavalryStrength += (getTroopStrength(3) * num);
        if (cavalryStrength < 0)
            cavalryStrength = 0;
        getTotalStrength();
        updateArmyStrings();
    }

    public int cavalryCount()
    {
        return cavalryStrength / troopStrength[3];
    }


    public void setCatapultSize(int num)
    {
        catapultStrength = troopStrength[4] * num;
    }

    public void addCatapult(int num)
    {
        catapultStrength += (getTroopStrength(4) * num);
        if (catapultStrength < 0)
            catapultStrength = 0;
        getTotalStrength();
        updateArmyStrings();
    }

    public int catapultCount()
    {
        return catapultStrength / troopStrength[4];
    }

     public string getNeedsString(int num)
    {
     return "Food: "   + troopNeeds[num].foodNeed.ToString() +
            "\nWood: " + troopNeeds[num].woodNeed.ToString() +
            "\nIron: " + troopNeeds[num].ironNeed.ToString();
    }
   

    public void setArmy(int farm, int sold, int arch, int caval, int catap)
    {
        setFarmerSize(farm);
        setSoldierSize(sold);
        setArcherSize(arch);
        setCavalrySize(caval);
        setCatapultSize(catap);


        totalStrength = farmerStrength + soldierStrength + archerStrength + cavalryStrength + catapultStrength;
        updateArmyStrings();
    }

    public int getHitChance(int num)
    {
        return hitChance[num];
    }

    protected void updateArmyStrings()
    {
        if (tag != "Enemy")
        {
            farmerText.text = farmerCount().ToString();
            soldierText.text = soldierCount().ToString();
            archerText.text = archerCount().ToString();
            cavalryText.text = cavalryCount().ToString();
            catapultText.text = catapultCount().ToString();
        }
    }


}
