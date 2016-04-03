using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {
    Camera camera;

    bool town;
    bool city;
    bool world;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    public void setCurrentCam(string s)
    {
        if (s == "Town")
        {
            town = true;
            city = false;
            world = false;
            setCameraPos();
        }

        if (s == "City")
        {
            city = true;
            town = false;
            world = false;
            setCameraPos();
        }
        if (s == "World")
        {
            world = true;
            town = false;
            city = false;
            setCameraPos();
        }
    }

    void setCameraPos()
    {
        if (town)
        {
            camera.fieldOfView = 130;
        }
        else if (city)
        {
            camera.fieldOfView = 165;
        }
        else
        {
            camera.fieldOfView = 175;
        }
    }
}
