using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas creditsMenu;
    public Button startButton;
    public Button creditsButton;

	// Use this for initialization
	void Start ()
	{
	    creditsMenu = creditsMenu.GetComponent<Canvas>();
	    startButton = startButton.GetComponent<Button>();
	    creditsButton = creditsButton.GetComponent<Button>();
	    creditsMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
