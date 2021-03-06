using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RestartLevel()
    {
       Scene scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
       Application.Quit();
    }

    public bool IsGamePaused { get => isGamePaused; set => isGamePaused = value; }
}
