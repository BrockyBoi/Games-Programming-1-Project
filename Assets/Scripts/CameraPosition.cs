using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {
    Camera camera;

    public static CameraPosition controller;

    bool town;
    bool city;
    bool world;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        setCurrentCam("Town");
        controller = this;
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
            camera.transform.position = new Vector3(-10.95f, -3.53f, -18);
            camera.fieldOfView = 136;
        }
        else if (city)
        {
            camera.transform.position = new Vector3(-35.54f, -19.4f, -18);
            camera.fieldOfView = 159.8f;
        }
        else
        {
            camera.fieldOfView = 175;
        }
    }

    public string getPosition()
    {
        if (town)
            return "Town";
        if (city)
            return "City";
        if (world)
            return "World";
        return "";
    }
}
