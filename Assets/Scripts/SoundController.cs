using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {
    public static SoundController controller;

    public Dictionary<string, AudioClip> tracks;
    AudioSource music;
    AudioSource fx;

    public AudioClip mainMusic;
    public AudioClip hammerSound;
    public AudioClip victory;
    public AudioClip battleHorn;
    public AudioClip marching;
    void Awake()
    {
        controller = this;
        tracks = new Dictionary<string, AudioClip>();
        music = GetComponent<AudioSource>();
        fx = gameObject.AddComponent<AudioSource>();

        tracks.Add("hammer", hammerSound);
        tracks.Add("music", mainMusic);
        tracks.Add("victory", victory);
        tracks.Add("battle horn", battleHorn);
        tracks.Add("marching", marching);
    }

	// Use this for initialization
	void Start () {
        music.Play();
        music.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playTrack(string s)
    {
        fx.PlayOneShot(tracks[s]);
        StartCoroutine(musicTimer());
    }

    IEnumerator musicTimer()
    {
        music.volume /= 2;
        float time = 0;
        while (time < 5)
        {
            time += Time.deltaTime;
            yield return null;
        }
        music.volume *= 2;
    }
}
