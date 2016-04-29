using UnityEngine;
using System.Collections;

public class BattleSystem : MonoBehaviour {
    public static BattleSystem controller;

    //Setup variables
    int fS1, fS2, sS1, sS2, aS1, aS2, cavS1, cavS2, catS1, catS2;
    //Percentages each part of the army makes up
    float fP1, fP2, sP1, sP2, aP1, aP2, cavP1, cavP2, catP1, catP2;
    //Hit chances
    float fH, sH, aH, cavH, catH;
    //Damage done
    float fD1, fD2, sD1, sD2, aD1, aD2, cavD1, cavD2, catD1, catD2, totalD1, totalD2;
    //Number of casualities
    int fC1, fC2, sC1, sC2, aC1, aC2, cavC1, cavC2, catC1, catC2;
    //Scripts
    Army army1;
    Army a1;
    Enemy army2, a2;

    void Awake()
    {
        controller = this;
    }

    // Use this for initialization
    void Start () {
        a1 = Army.controller;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setEnemy(Enemy e)
    {
        a2 = e;
    }

    public void fight()
    {
        fS1 = 0;
        sS1 = 0;
        aS1 = 0;
        cavS1 = 0;
        catS1 = 0;

        fS2 = 0;
        sS2 = 0;
        aS2 = 0;
        cavS2 = 0;
        catS2 = 0;

        army1 = a1;
        army2 = a2;

        fH = army1.getHitChance(0);
        sH = army1.getHitChance(1);
        aH = army1.getHitChance(2);
        cavH = army1.getHitChance(3);
        catH = army1.getHitChance(4);

        //Calc each army's strength and how much each units makes up of the army

        //fS1 = a1.getFarmerStrength();
        for(int i = 0; i < a1.farmerCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (fH < num)
                fS1 += Army.controller.getTroopStrength(0);
        }
        fP1 = (float)a1.farmerCount() / a1.armyCount();

        for (int i = 0; i < a1.soldierCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (sH < num)
                sS1 += Army.controller.getTroopStrength(1);
        }
        sP1 = (float)a1.soldierCount() / a1.armyCount();

        for (int i = 0; i < a1.archerCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (aH < num)
                aS1 += Army.controller.getTroopStrength(2);
        }
        aP1 = (float)a1.archerCount() / a1.armyCount();

        for (int i = 0; i < a1.cavalryCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (cavH < num)
                cavS1 += Army.controller.getTroopStrength(3);
        }
        cavP1 = (float)a1.cavalryCount() / a1.armyCount();

        for (int i = 0; i < a1.catapultCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (catH < num)
                catS1 += Army.controller.getTroopStrength(4);
        }
        catP1 = (float)a1.catapultCount() / a1.armyCount();



        for (int i = 0; i < a2.farmerCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (fH < num)
                fS2 += Army.controller.getTroopStrength(0) - Army.controller.getForgeStrength();
        }
        fP2 = (float)a2.farmerCount() / a2.armyCount();

        for (int i = 0; i < a2.soldierCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (sH < num)
                sS2 += Army.controller.getTroopStrength(1) - Army.controller.getForgeStrength();
        }
        sP2 = (float)a2.soldierCount() / a2.armyCount();

        for (int i = 0; i < a2.archerCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (aH < num)
                aS2 += Army.controller.getTroopStrength(2) - Army.controller.getForgeStrength();
        }
        aP2 = (float)a2.archerCount() / a2.armyCount();

        for (int i = 0; i < a2.cavalryCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (fH < num)
                cavS2 += Army.controller.getTroopStrength(3) - Army.controller.getForgeStrength();
        }
        cavP2 = (float)a2.cavalryCount() / a2.armyCount();

        for (int i = 0; i < a2.catapultCount(); i++)
        {
            float num = Random.Range(0, 100);
            if (catH < num)
                catS2 += Army.controller.getTroopStrength(4) - Army.controller.getForgeStrength();
    }
        catP2 = (float)a2.catapultCount() / a2.armyCount();

        battle();
    }

    void battle()
    {
        //How much damage each army does
        fD1 = fS1;
        sD1 = sS1;
        aD1 = aS1;
        cavD1 = cavS1;
        catD1 = catS1;
        totalD1 = fD1 + sD1 + aD1 + cavD1 + catD1;

        fD2 = fS2;
        sD2 = sS2;
        aD2 = aS2;
        cavD2 = cavS2;
        catD2 = catS2;
        totalD2 = fD2 + sD2 + aD2 + cavD2 + catD2;

        //Casualites taken by each army
        fC1 = (int)((totalD2 * fP1) / Army.controller.getTroopStrength(0));
        sC1 = (int)((totalD2 * sP1) /     Army.controller.getTroopStrength(1));
        aC1 = (int)((totalD2 * aP1) /     Army.controller.getTroopStrength(2));
        cavC1 = (int)((totalD2 * cavP1) / Army.controller.getTroopStrength(3));
        catC1 = (int)((totalD2 * catP1) / Army.controller.getTroopStrength(4));

        army1.addFarmer(-fC1);
        army1.addSoldier(-sC1);
        army1.addArcher(-aC1);
        army1.addCavalry(-cavC1);
        army1.addCatapult(-catC1);

        fC2 = (int)(totalD1 * fP2);
        sC2 = (int)((totalD1 * sP2) /     Army.controller.getTroopStrength(1)) - Army.controller.getForgeStrength();
        aC2 = (int)((totalD1 * aP2) /     Army.controller.getTroopStrength(2)) - Army.controller.getForgeStrength();
        cavC2 = (int)((totalD1 * cavP2) / Army.controller.getTroopStrength(3)) - Army.controller.getForgeStrength();
        catC2 = (int)((totalD1 * catP2) / Army.controller.getTroopStrength(4)) - Army.controller.getForgeStrength();

        army2.addFarmer(-fC2);
        army2.addSoldier(-sC2);
        army2.addArcher(-aC2);
        army2.addCavalry(-cavC2);
        army2.addCatapult(-catC2);

        BuildingUpgradeCanvas.controller.updateEnemyStrings();

        if (army1.getTotalStrength() > 1 && army2.getTotalStrength() > 1)
            battle();

        if (army2.getTotalStrength() < 1)
        {
            ResourceController.controller.addResourceBoost(army2.getResourceType(), army2.getResourceBoost());
            enabled = false;
        }
    }
}
