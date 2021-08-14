using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuObject;
    private bool isMenuDisplayed;
    [SerializeField]
    private GameManager gameManagerScript;
    [SerializeField]
    private GameObject exitTextObject;
    private bool isPauseMenuCloseEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isMenuDisplayed)
            {
                DisplayMenu(true);
            } else if(isMenuDisplayed && isPauseMenuCloseEnabled)
            {
                CloseMenu();
            }
        }

        if (isMenuDisplayed)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameManagerScript.RestartLevel();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                gameManagerScript.QuitGame();
            }
        }
    }

    public void DisplayMenu(bool isExitMenuEnabled)
    {
        isPauseMenuCloseEnabled = isExitMenuEnabled;
        this.menuObject.SetActive(true);
        isMenuDisplayed = true;
        gameManagerScript.IsGamePaused = true;

        if (!isExitMenuEnabled)
        {
            exitTextObject.SetActive(false);
        }
        else
        {
            exitTextObject.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        this.menuObject.SetActive(false);
        isMenuDisplayed = false;
        gameManagerScript.IsGamePaused = false;
        isPauseMenuCloseEnabled = true;
    }
}
