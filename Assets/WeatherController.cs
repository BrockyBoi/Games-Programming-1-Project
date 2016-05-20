using UnityEngine;
using System.Collections;

public class WeatherController : MonoBehaviour {
    public ParticleSystem rain;
    public ParticleSystem snow;
    void Awake()
    {
        Deactivate(snow);
        Deactivate(rain);
    }

	// Use this for initialization
	void Start () {
        InvokeRepeating("PlayRain", 60, 300);

        InvokeRepeating("PlaySnow", 200, 300);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayRain()
    {
        Activate(rain);

        Invoke("StopRain", 45);
    }

    void StopRain()
    {
        Deactivate(rain);
    }

    void PlaySnow()
    {
        Activate(snow);

        Invoke("StopSnow", 45);
    }

    void StopSnow()
    {
        Deactivate(snow);
    }

    void Activate(ParticleSystem p)
    {
        p.Play();
    }

    void Deactivate(ParticleSystem p)
    {
        p.Stop();
    }
}
