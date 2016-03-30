using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Producer : Building
{
    public float productionRate;
    protected int produceAmount;
    protected int nextProduceAmount;
    protected int lastResourceCap;
    protected int resourceCap;

    protected bool farm;
    protected bool forestry;
    protected bool quarry;
    protected bool smith;

    // Use this for initialization
    protected new void Start()
    {
        base.Start();
        produceLevel();
        getCap();
        setControllerCap();

        // productionRate = 15;

        InvokeRepeating("addResource", productionRate, productionRate);
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

    void addResource()
    {
        if (farm)
            controller.addFood(produceAmount);
        else if (forestry)
            controller.addLogs(produceAmount);
        else if (smith)
            controller.addIron(produceAmount);
        else
            controller.addRocks(produceAmount);
    }
    public override void upgrade()
    {
        if (controller.getFood() >= u.foodNeeded && 
            controller.getIron() >= u.ironNeeded && 
            controller.getLogs() >= u.logsNeeded && 
            controller.getRocks() >= u.rocksNeeded && level < 5)
        {
            level++;

            controller.subtractFood(u.foodNeeded);
            controller.subtractIron(u.ironNeeded);
            controller.subtractLogs(u.logsNeeded);
            controller.subtractRocks(u.rocksNeeded);

            produceLevel();
            setControllerCap();
            upgradeParameters();
        }
    }

    void produceLevel()
    {
        //This is the produce amount every 5 minutes, so I take the base number and divide it by 20 (15 seconds * 4 = one minute, 5 minutes, so 4 * 5)
        switch (level)
        {
            case 1:
                produceAmount = 500 / 20;
                nextProduceAmount = 1250 / 20;
                break;
            case 2:
                produceAmount = 1250 / 20;
                nextProduceAmount = 2500 / 20;
                break;
            case 3:
                produceAmount = 2500 / 20;
                nextProduceAmount = 5000 / 20;
                break;
            case 4:
                produceAmount = 5000 / 20;
                nextProduceAmount = 10000 / 20;
                break;
            case 5:
                produceAmount = 10000 / 20;
                break;
            default:
                break;
        }
        if (level < 5)
            production = "Current produce amount: " + produceAmount.ToString() + "\nNext produce amount: " + nextProduceAmount.ToString();
        else production = "Current produce amount: " + produceAmount.ToString();
    }

    void getCap()
    {
        switch (level)
        {
            case 1:
                lastResourceCap = 0;
                resourceCap = 1500;
                break;
            case 2:
                lastResourceCap = 1500;
                resourceCap = 5000;
                break;
            case 3:
                lastResourceCap = 5000;
                resourceCap = 8000;
                break;
            case 4:
                lastResourceCap = 8000;
                resourceCap = 15000;
                break;
            case 5:
                lastResourceCap = 15000;
                resourceCap = 40000;
                break;
            default:
                break;
        }
    }

    void setControllerCap()
    {
        getCap();

        if (forestry)
            controller.setLogCap(controller.getLogCap() + resourceCap - lastResourceCap);
        else if (smith)
            controller.setIronCap(controller.getIronCap() + resourceCap - lastResourceCap);
        else if (quarry)
            controller.setRockCap(controller.getRockCap() + resourceCap - lastResourceCap);
        else
            controller.setFoodCap(controller.getFoodCap() + resourceCap - lastResourceCap);
    }
}