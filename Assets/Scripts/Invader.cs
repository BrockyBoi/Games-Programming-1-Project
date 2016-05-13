using UnityEngine;
using System.Collections;

public class Invader : Army {

    public static Invader invaderArmy;

    float marchTime;
    float prepareTime;

    int round;

    int[] plannedSoldiers;

    void Awake()
    {
        plannedSoldiers = new int[5];
        invaderArmy = this;
    }

	// Use this for initialization
	new void Start () {
        base.Start();
        prepareTime = 2;
        StartCoroutine(prepareTimer());
        round = 1;
        increaseArmy();
	}
	
	// Update is called once per frame
	new void Update () {
	
	}

    IEnumerator prepareTimer()
    {
        float time = 0;
        while(time < prepareTime - 1)
        {
            time += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(marchTimer());  
    }

    IEnumerator marchTimer()
    {
        SoundController.controller.playTrack("battle horn");
        float time = 0;
        marchTime = getMarchTime();
        while(time < marchTime - 1)
        {
            time += Time.deltaTime;
            BuildingUpgradeCanvas.controller.setInvaderText(marchTime - time);
            yield return null;
        }

        Debug.Log("Before");
        setArmy(plannedSoldiers[0],
                plannedSoldiers[1],
                plannedSoldiers[2],
                plannedSoldiers[3],
                plannedSoldiers[4]);

        Debug.Log("After");
        BattleSystem.controller.startFightWithInvader();
        increaseArmy();
        StartCoroutine(prepareTimer());
    }

    float getMarchTime()
    {
        return 10 * 60 + (Army.controller.getAlarmBoost() * 2 * 60);
    }

    public override float getResourceBoost()
    {
        return base.getResourceBoost();
    }

    public override string getResourceType()
    {
        return base.getResourceType();
    }

    void increaseArmy()
    {
        if(round < 2)
        {
            addInvader(0, 25);
        }
        else if(round < 3)
        {
            addInvader(0, 50);
            addInvader(1, 25);
        }
        else if(round < 5)
        {
            addInvader(0, 50);
            addInvader(1, 50);
            addInvader(2, 50);
        }
        else if(round < 7)
        {
            addInvader(0, 50);
            addInvader(1, 50);
            addInvader(2, 50);
            addInvader(3, 25);
        }
        else
        {
            addInvader(0, 50);
            addInvader(1, 50);
            addInvader(2, 50);
            addInvader(3, 25);
            addInvader(4, 5);
        }
    }

    void setInvader(int f, int s, int a, int cav, int cat)
    {
        plannedSoldiers[0] = f;
        plannedSoldiers[1] = s;
        plannedSoldiers[2] = a;
        plannedSoldiers[3] = cav;
        plannedSoldiers[4] = cat;
    }

    void addInvader(int num, int amount)
    {
        plannedSoldiers[num] += amount;
    }

}
