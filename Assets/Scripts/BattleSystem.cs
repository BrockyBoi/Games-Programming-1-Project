using UnityEngine;
using System.Collections;

public class BattleSystem : MonoBehaviour {
    //Setup variables
    int fS1, fS2, sS1, sS2, aS1, aS2, cavS1, cavS2, catS1, catS2;
    //Percentages each part of the army makes up
    float fP1, fP2, sP1, sP2, aP1, aP2, cavP1, cavP2, catP1, catP2;
    //Hit chances
    int fH, sH, aH, cavH, catH;
    //Damage done
    float fD1, fD2, sD1, sD2, aD1, aD2, cavD1, cavD2, catD1, catD2, totalD1, totalD2;
    //Number of casualities
    int fC1, fC2, sC1, sC2, aC1, aC2, cavC1, cavC2, catC1, catC2;
    //Scripts
    Army army1, army2;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setUp(Army a1, Army a2)
    {
        army1 = a1;
        army2 = a2;

        fH = army1.getFarmer().hitChance / 100;
        sH = army1.getSoldier().hitChance / 100;
        aH = army1.getArcher().hitChance / 100;
        cavH = army1.getCavalry().hitChance / 100;
        catH = army1.getCatapult().hitChance / 100;

        //Calc each army's strength and how much each units makes up of the army

        //fS1 = a1.getFarmerStrength();
        for(int i = 0; i < a1.farmerCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (fH < num)
                fS1 += a1.getFarmerStrength();
        }
        fP1 = a1.farmerCount() / a1.armyCount();

        for (int i = 0; i < a1.soldierCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (sH < num)
                sS1 += a1.getSoldierStrength();
        }
        sP1 = a1.soldierCount() / a1.armyCount();

        for (int i = 0; i < a1.archerCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (aH < num)
                aS1 += a1.getArcherStrength();
        }
        aP1 = a1.archerCount() / a1.armyCount();

        for (int i = 0; i < a1.cavalryCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (cavH < num)
                cavS1 += a1.getCavalryStrength();
        }
        cavP1 = a1.cavalryCount() / a1.armyCount();

        for (int i = 0; i < a1.catapultCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (catH < num)
                catS1 += a1.getCatapultStrength();
        }
        catP1 = a1.catapultCount() / a1.armyCount();



        for (int i = 0; i < a2.farmerCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (fH < num)
                fS2 += a2.getFarmerStrength();
        }
        fP2 = a2.farmerCount() / a2.armyCount();

        for (int i = 0; i < a2.soldierCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (sH < num)
                sS2 += a2.getSoldierStrength();
        }
        sP2 = a2.soldierCount() / a2.armyCount();

        for (int i = 0; i < a2.archerCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (aH < num)
                aS2 += a2.getArcherStrength();
        }
        aP2 = a2.archerCount() / a2.armyCount();

        for (int i = 0; i < a2.cavalryCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (fH < num)
                cavS2 += a2.getCavalryStrength();
        }
        cavP2 = a2.cavalryCount() / a2.armyCount();

        for (int i = 0; i < a2.catapultCount(); i++)
        {
            int num = Random.Range(0, 1);
            if (catH < num)
                catS2 += a2.getCatapultStrength();
        }
        catP2 = a2.catapultCount() / a2.armyCount();

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
        fC1 = (int)(totalD2 * fP1);
        sC1 = (int)((totalD2 * sP1) / army1.getSoldierStrength());
        aC1 = (int)((totalD2 * aP1) / army1.getArcherStrength());
        cavC1 = (int)((totalD2 * cavP1) / army1.getCavalryStrength());
        catC1 = (int)((totalD2 * catP1) / army1.getCatapultStrength());

        army1.setFarmerSize((army1.farmerCount() - fC1));
        army1.setSoldierSize((army1.soldierCount() - sC1));
        army1.setArcherSize((army1.archerCount() - aC1));
        army1.setCavalrySize((army1.cavalryCount() - cavC1));
        army1.setCatapultSize((army1.catapultCount() - catC1));

        fC2 = (int)(totalD1 * fP2);
        sC2 = (int)((totalD1 * sP2) / army2.getSoldierStrength());
        aC2 = (int)((totalD1 * aP2) / army2.getArcherStrength());
        cavC2 = (int)((totalD1 * cavP2) / army2.getCavalryStrength());
        catC2 = (int)((totalD1 * catP2) / army2.getCatapultStrength());

        army2.setFarmerSize((army2.farmerCount() - fC2));
        army2.setSoldierSize((army2.soldierCount() - sC2));
        army2.setArcherSize((army2.archerCount() - aC2));
        army2.setCavalrySize((army2.cavalryCount() - cavC2));
        army2.setCatapultSize((army2.catapultCount() - catC2));

        if (army1.getTotalStrength() > 1 && army2.getTotalStrength() > 1)
            battle();   
    }
}
