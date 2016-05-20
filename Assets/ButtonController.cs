using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
    public Button playButton;
    public Button quitButton;
    public Button instructionButton;

    public GameObject instructions;


	// Use this for initialization
	void Start () {
        //instructions.gameObject.SetActive(false);
        PressExit();
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

    public void PressInstructions()
    {
        instructions.gameObject.SetActive(true);
    }

    public void PressExit()
    {
        instructions.gameObject.SetActive(false);
    }
}
