using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class GameModel : MonoBehaviour {
    private static GameModel mSingleton;
    public static GameModel Instance { get { return mSingleton; } }

    public string saveFileName;

    public ResourceController resources;
    public Army army;
    public BuildingController buildingController;
    public Invader invaders;
    public BattleSystem battleSystem;

    public GameObject plotList;
    public GameObject buildingList;
    public GameObject enemyList;

    int buildingNum;

    void Awake()
    {
        if(mSingleton == null)
        {
            mSingleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //resources = GameObject.Find("Resource Controller").GetComponent<ResourceController>();
        //army = GameObject.Find("Army Controller").GetComponent<Army>();
        //buildingController = GameObject.Find("Building Controller").GetComponent<BuildingController>();
        //invaders = GameObject.Find("Invader Controller").GetComponent<Invader>();
        //battleSystem = GameObject.Find("Battle System Controller").GetComponent<BattleSystem>();
    }
    
    public void OnSaveClick()
    {
        SaveGame saveGame = new SaveGame();

        SaveGameModel(saveGame, saveFileName);
    }

    public void OnLoadClick()
    {
        LoadGame(saveFileName);
    }

    public void SaveGameModel(SaveGame save, string filename)
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream fs = File.Create(Application.persistentDataPath + "/" + filename + ".dat");

        save.StoreData(this);

        bf.Serialize(fs, save);

        fs.Close();
    }

    public void LoadGame(string filename)
    {
        if (File.Exists(Application.persistentDataPath + "/" + filename + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = File.Open(Application.persistentDataPath + "/" + filename + ".dat",FileMode.Open);

            SaveGame saveGame = (SaveGame)bf.Deserialize(fs);

            saveGame.LoadData(this);

            fs.Close();
        }
    }

    public void GiveResources(SaveGame save)
    {
        save.food = resources.getFood();
        save.wood = resources.getLogs();
        save.iron = resources.getIron();
        save.stone = resources.getRocks();

        save.foodCap = resources.getFoodCap();
        save.woodCap = resources.getLogCap();
        save.ironCap = resources.getIronCap();
        save.stoneCap = resources.getRockCap();

        save.foodRate = resources.GetResourceRate("Farm");
        save.woodRate = resources.GetResourceRate("Forestry");
        save.ironRate = resources.GetResourceRate("Mine");
        save.stoneRate = resources.GetResourceRate("Quarry");

        save.foodBoost = resources.GetResourceRate("Food");
        save.woodBoost = resources.GetResourceRate("Wood");
        save.ironBoost = resources.GetResourceRate("Iron");
        save.stoneBoost = resources.GetResourceRate("Stone");

        save.population = resources.getPopulation();
        save.popCap = resources.GetPopCap();
    }

    public void SetResources(SaveGame save)
    {
        resources.SetMultiple(save.food, save.wood, save.iron, save.stone);
        resources.SetMultipleCaps(save.foodCap, save.woodCap, save.ironCap, save.stoneCap);
        resources.SetMultipleRates(save.foodRate, save.woodRate, save.ironRate, save.stoneRate);
        resources.SetMultipleBoosts(save.foodBoost, save.woodBoost, save.ironBoost, save.stoneBoost);

        resources.setPopCap(save.popCap);
        resources.SetPopulation(save.population);
        resources.updateResourceText();
    }

    public void GivePlotInfo(SaveGame save)
    {
        save.plotList = new System.Collections.Generic.List<bool>();

        int activePlots = 0;
        for(int i = 0; i < plotList.transform.childCount; i++)
        {
            if(plotList.transform.GetChild(i).gameObject.active)
            {
                activePlots++;
            }
        }

        for(int i = 0; i < activePlots; i++)
        {
             save.plotList.Add(plotList.transform.GetChild(i).GetComponent<Plot>().getEmpty());
        }
    }

    public void SetPlotInfo(SaveGame save)
    {
        for(int i = 0; i < plotList.transform.childCount; i++)
        {
            plotList.transform.GetChild(i).gameObject.SetActive(true);
            plotList.transform.GetChild(i).GetComponent<Plot>().setEmpty(save.plotList[i]);
            plotList.transform.GetChild(i).GetComponent<Plot>().CheckEmpty();
        }
    }

    public void GiveBuildingInfo(SaveGame save)
    {
        Debug.Log(buildingList.transform.childCount);
        buildingNum = buildingList.transform.childCount;
        save.buildingList = new System.Collections.Generic.List<float[]>();
        for (int i = 0; i < buildingList.transform.childCount; i++)
        {
            //save.buildingList.Add(new float[2] { buildingList.transform.GetChild(i).transform.position.x, buildingList.transform.GetChild(i).transform.position.y });
            save.buildingNames.Add(buildingList.transform.GetChild(i).GetComponent<Building>().GetName());
            save.buildingLevels.Add(new float[3] { buildingList.transform.GetChild(i).GetComponent<Building>().GetLevel(), buildingList.transform.GetChild(i).GetComponent<Building>().GetPosition().x, buildingList.transform.GetChild(i).GetComponent<Building>().GetPosition().y });
        }
    }

    public void SetBuildingInfo(SaveGame save)
    {
        for(int i = 0; i < buildingList.transform.childCount; i++)
        {
            if(buildingList.transform.GetChild(i).GetComponent<Building>().GetName() != "Town Hall")
                 Destroy(buildingList.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < buildingNum; i++)
        {
            //buildingList.transform.GetChild(i).transform.position = new Vector3(save.buildingList[i][0], save.buildingList[i][1]);
            if (save.buildingNames[i] != "Town Hall")
            {
                buildingController.BuildBuilding(save.buildingNames[i], (int)save.buildingLevels[i][0], save.buildingLevels[i][1], save.buildingLevels[i][2]);
            }
            else
            {
                buildingList.transform.GetChild(i).GetComponent<Building>().SetParameters((int)save.buildingLevels[i][0]);
            }
        }
    }

    public void GiveEnemyInfo(SaveGame save)
    {
        save.enemyList = new System.Collections.Generic.List<int[]>();
        for(int i = 0; i < enemyList.transform.childCount; i++)
        {
            save.enemyList.Add(new int[5] { enemyList.transform.GetChild(i).GetComponent<Enemy>().farmerCount(),
                                             enemyList.transform.GetChild(i).GetComponent<Enemy>().soldierCount(),
                                             enemyList.transform.GetChild(i).GetComponent<Enemy>().archerCount(),
                                             enemyList.transform.GetChild(i).GetComponent<Enemy>().cavalryCount(),
                                             enemyList.transform.GetChild(i).GetComponent<Enemy>().catapultCount() });
        }
    }

    public void SetEnemyInfo(SaveGame save)
    {
        for(int i = 0; i < enemyList.transform.childCount; i++)
        {
            enemyList.transform.GetChild(i).GetComponent<Enemy>().setArmy(save.enemyList[i][0], 
                                                                          save.enemyList[i][1], 
                                                                          save.enemyList[i][2], 
                                                                          save.enemyList[i][3], 
                                                                          save.enemyList[i][4]);
            enemyList.transform.GetChild(i).GetComponent<Enemy>().checkHealth();
        }
    }

    public void GiveArmy(SaveGame save)
    {
        save.farmers = army.farmerCount();
        save.soldiers = army.soldierCount();
        save.archers = army.archerCount();
        save.cavalry = army.cavalryCount();
        save.catapults = army.catapultCount();

        save.accuracyBoost = army.GetAccuracyBoost();
        save.trainingBoost = army.GetTrainingBoost();
    }

    public void SetArmy(SaveGame save)
    {
        army.setArmy(save.farmers, save.soldiers, save.archers, save.cavalry, save.catapults);

        army.SetTrainingBoost(save.trainingBoost);
        army.SetAccuracyBoost(save.accuracyBoost);
    }

    public void GiveGeneralBoosts(SaveGame save)
    {
        save.constructionBoost = buildingController.getUpgradeBoost();
        save.alarmBoost = army.getAlarmBoost();
        save.marchingBoost = battleSystem.GetMarchingBoost();
    }

    public void SetGeneralBoosts(SaveGame save)
    {
        buildingController.SetUpgradeBoost(save.constructionBoost);
        army.SetAlarmBoost(save.alarmBoost);
        battleSystem.SetMarchingBoost(save.marchingBoost);
    }
  
}
