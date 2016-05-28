using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

[Serializable]
public class SaveGame : ISerializable {
    public int food, foodCap, wood, woodCap, iron, ironCap, stone, stoneCap, population, popCap;
    public float foodRate, woodRate, ironRate, stoneRate;
    public float foodBoost, woodBoost, ironBoost, stoneBoost;
    public int farmers, soldiers, archers, cavalry, catapults;
    public float accuracyBoost, trainingBoost;
    public float constructionBoost, marchingBoost;
    public int alarmBoost;

    //Only needs to check if the plot is empty or not
    public List<bool> plotList = new List<bool>();
    //Only needs the building transforms
    public List<float[]> buildingList = new List<float[]>();

    public List<string> buildingNames = new List<string>();
    public List<float[]> buildingLevels = new List<float[]>();

    public List<int[]> enemyList = new List<int[]>();


    public void StoreData(GameModel model)
    {
        model.GiveResources(this);
        model.GiveArmy(this);
        model.GiveGeneralBoosts(this);
        //Debug.Log("Hi!");
        model.GivePlotInfo(this);
        //Debug.Log("This work");
        model.GiveBuildingInfo(this);
        //Debug.Log("hi");
        model.GivePlotInfo(this);
       // Debug.Log("Hi");
        model.GiveEnemyInfo(this);
        //Debug.Log("Made it past StoreData");
        Debug.Log(food);
    }

    public void LoadData(GameModel model)
    {
        model.SetResources(this);
        model.SetArmy(this);
        model.SetGeneralBoosts(this);
        //Debug.Log("Made it this far");
        model.SetPlotInfo(this);
        model.SetBuildingInfo(this);
        model.SetEnemyInfo(this);
        //Debug.Log("Made it past LoadData");
    }


    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("food", food);
        info.AddValue("foodCap", foodCap);
        info.AddValue("foodBoost", foodBoost);

        info.AddValue("wood", wood);
        info.AddValue("woodCap", woodCap);
        info.AddValue("woodBoost", woodBoost);

        info.AddValue("iron", iron);
        info.AddValue("ironCap", ironCap);
        info.AddValue("ironBoost", ironBoost);

        info.AddValue("stone", stone);
        info.AddValue("stoneCap", stoneCap);
        info.AddValue("stoneBoost", stoneBoost);

        info.AddValue("population", population);
        info.AddValue("popCap", popCap);

        info.AddValue("farmers", farmers);
        info.AddValue("soldiers", soldiers);
        info.AddValue("archers", archers);
        info.AddValue("cavalry", cavalry);
        info.AddValue("catapults", catapults);

        info.AddValue("accuracyBoost", accuracyBoost);
        info.AddValue("alarmBoost", alarmBoost);
        info.AddValue("trainingBoost", trainingBoost);
        info.AddValue("constructionBoost", constructionBoost);
        info.AddValue("marchingBoost", marchingBoost);

        info.AddValue("plotList", plotList);
        info.AddValue("buildingList", buildingList);
        info.AddValue("buildingNames", buildingNames);
        info.AddValue("buildingLevels", buildingLevels);
        info.AddValue("enemyList", enemyList);
    }


    void GetValue(SerializationInfo info, StreamingContext context,string s, ref int i)
    {
        i =  info.GetInt32(s);
        //Debug.Log(s + ": " + info.GetInt32(s));
    }

    void GetValueF(SerializationInfo info, StreamingContext context,string s, ref float f)
    {
        f =  info.GetSingle(s);
        //Debug.Log(s + ": " + info.GetSingle(s));
    }

    public SaveGame()
    { }

    public SaveGame(SerializationInfo info, StreamingContext context)
    {
        food = info.GetInt32("food");
        Debug.Log(food);
        //GetValue(info, context, "food", food);
        GetValue(info, context, "foodCap", ref foodCap);
        GetValueF(info, context, "foodBoost", ref foodBoost);
                       
        GetValue(info, context, "wood", ref wood);
        GetValue(info, context, "woodCap", ref woodCap);
        GetValueF(info, context, "woodBoost", ref woodBoost);
                     
        GetValue(info, context, "iron", ref iron);
        iron = info.GetInt32("iron");
        GetValue(info, context, "ironCap", ref ironCap);
        GetValueF(info, context, "ironBoost", ref ironBoost);

        GetValue(info, context, "stone", ref stone);
        stone = info.GetInt32("stone");
        GetValue(info, context, "stoneCap", ref stoneCap);
        GetValueF(info, context, "stoneBoost", ref stoneBoost);
                       
        GetValue(info, context, "farmers", ref farmers);
        GetValue(info, context, "soldiers", ref soldiers);
        GetValue(info, context, "archers", ref archers);
        GetValue(info, context, "cavalry", ref cavalry);
        GetValue(info, context, "catapults", ref catapults);
                      
        GetValueF(info, context, "accuracyBoost", ref accuracyBoost);
        GetValue(info, context, "alarmBoost", ref alarmBoost);
        GetValueF(info, context, "trainingBoost", ref trainingBoost);
        GetValueF(info, context, "constructionBoost", ref constructionBoost);
        GetValueF(info, context, "marchingBoost", ref marchingBoost);
                      
        GetValue(info, context, "population", ref population);
        GetValue(info, context, "popCap", ref popCap);

        plotList = (List<bool>)info.GetValue("plotList", plotList.GetType());
        buildingList = (List<float[]>)info.GetValue("buildingList", buildingList.GetType());
        buildingNames = (List<string>)info.GetValue("buildingNames", buildingNames.GetType());
        buildingLevels = (List<float[]>)info.GetValue("buildingLevels", buildingLevels.GetType());
        enemyList = (List<int[]>)info.GetValue("enemyList", enemyList.GetType());

    }   
}       
        
        
        
        
        
        