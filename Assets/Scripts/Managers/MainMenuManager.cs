using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LaunchGame()
    {
        SceneManager.LoadScene("Game_start_scene");
    }
}