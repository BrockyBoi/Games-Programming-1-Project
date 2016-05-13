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
            camera.transform.position = new Vector3(-10f, 5.15f, -50);
            camera.orthographicSize = 55;
        }
        else if (city)
        {
            camera.transform.position = new Vector3(-18, -19.38f, -50);
            camera.orthographicSize = 100;
        }
        else
        {
            camera.transform.position = new Vector3(-34f, -34f, -50);
            camera.orthographicSize = 900;
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
