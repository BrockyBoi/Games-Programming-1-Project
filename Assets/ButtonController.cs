using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
    public Button playButton;
    public Button quitButton;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void pressPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void pressQuit()
    {
        Application.Quit();
    }
}
