using UnityEngine;
using System.Collections;

public class Barracks : Building {
    Canvas soldierList;
    Army armyController;
    bool soldier;
    bool archer;
    bool cavalry;
    bool catapult;

	// Use this for initialization
	new void Start () {
        base.Start();
        armyController = GameObject.Find("Army Controller").GetComponent<Army>();
        soldierList = GameObject.Find("BuySoldiersCanvas").GetComponent<Canvas>();
        soldierList.gameObject.SetActive(false);
        buildingName = "Barracks";
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

   // new void OnMouseDown()
   // {
        //soldierList.gameObject.SetActive(true);
   // }

    public void buyFarmer(int num)
    {
        if(    controller.getFood() >= armyController.f.need.foodNeed * num
            && controller.getLogs() >= armyController.f.need.woodNeed * num
            && controller.getIron() >= armyController.f.need.ironNeed * num
            && controller.getPopulation() > 0)
        {
            armyController.addFarmer(num);

            controller.subtractPopulation(num);
            controller.subtractFood(armyController.f.need.foodNeed * num);
            controller.subtractIron(armyController.f.need.ironNeed * num);
            controller.subtractLogs(armyController.f.need.woodNeed * num);
        }
    }

    public void buySoldier(int num)
    {
        if (soldier && controller.getFood() >= armyController.s.need.foodNeed * num
            &&         controller.getLogs() >= armyController.s.need.woodNeed * num
            &&         controller.getIron() >= armyController.s.need.ironNeed * num
            && controller.getPopulation() > 0)
        {
            armyController.addSoldier(num);

            controller.subtractPopulation(num);
            controller.subtractFood(armyController.s.need.foodNeed * num);
            controller.subtractIron(armyController.s.need.ironNeed * num);
            controller.subtractLogs(armyController.s.need.woodNeed * num);
        }
    }

    public void buyArcher(int num)
    {
        if (archer && controller.getFood() >= armyController.a.need.foodNeed * num
            &&        controller.getLogs() >= armyController.a.need.woodNeed * num
            &&        controller.getIron() >= armyController.a.need.ironNeed * num
            && controller.getPopulation() > 0)
        {
            armyController.addArcher(num);

            controller.subtractPopulation(num);
            controller.subtractFood(armyController.a.need.foodNeed * num);
            controller.subtractIron(armyController.a.need.ironNeed * num);
            controller.subtractLogs(armyController.a.need.woodNeed * num);
        }
    }

    public void buyCavalry(int num)
    {
        if (cavalry && controller.getFood() >= armyController.cav.need.foodNeed * num
            &&         controller.getLogs() >= armyController.cav.need.woodNeed * num
            &&         controller.getIron() >= armyController.cav.need.ironNeed * num
            && controller.getPopulation() > 0)
        {
            armyController.addCavalry(num);

            controller.subtractPopulation(num);
            controller.subtractFood(armyController.cav.need.foodNeed * num);
            controller.subtractIron(armyController.cav.need.ironNeed * num);
            controller.subtractLogs(armyController.cav.need.woodNeed * num);
        }
    }

    public void buyCatapult(int num)
    {
        if (catapult && controller.getFood() >= armyController.cat.need.foodNeed * num
            &&          controller.getLogs() >= armyController.cat.need.woodNeed * num
            &&          controller.getIron() >= armyController.cat.need.ironNeed * num
            && controller.getPopulation() > 0)
        {
            armyController.addCatapult(num);

            controller.subtractPopulation(num);
            controller.subtractFood(armyController.cat.need.foodNeed * num);
            controller.subtractIron(armyController.cat.need.ironNeed * num);
            controller.subtractLogs(armyController.cat.need.woodNeed * num);
        }
    }

    public override void upgrade()
    {
        if (controller.getFood() >= u.foodNeeded && 
            controller.getIron() >= u.ironNeeded && 
            controller.getLogs() >= u.logsNeeded && 
            controller.getRocks() >= u.rocksNeeded && 
            level < 5)
        {
            level++;

            controller.subtractFood(u.foodNeeded);
            controller.subtractIron(u.ironNeeded);
            controller.subtractLogs(u.logsNeeded);
            controller.subtractRocks(u.rocksNeeded);

            availableUnits();
            upgradeParameters();
        }
    }

    void availableUnits()
    {
        switch(level)
        {
            case 2:
                soldier = true;
                break;
            case 3:
                soldier = true;
                archer = true;
                break;
            case 4:
                soldier = true;
                archer = true;
                cavalry = true;
                break;
            case 5:
                soldier = true;
                archer = true;
                cavalry = true;
                catapult = true;
                break;
            default:
                break;
        }
    }

    protected override void upgradeParameters()
    {
        //Cap bases are 1500, 5000, 8000, 15000
        //Food, wood, iron, stone
        switch (level)
        {
            case 1:
                setNeeds(500, 400, 800, 800);
                break;
            case 2:
                setNeeds(3000, 2750, 4000, 4000);
                break;
            case 3:
                setNeeds(5500, 5000, 7500, 7500);
                break;
            case 4:
                setNeeds(15000, 13500, 20000, 20000);
                break;
            default:
                break;
        }
    }


}
