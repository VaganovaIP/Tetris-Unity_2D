using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private bool pause_ = false;
    public GameObject pausedGame;

    public void Play() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume() {
        
        pausedGame.SetActive(true);
        pause_ = false;
        Time.timeScale = 1f;

    }

    public void Pause()
    {
         pausedGame.SetActive(false);
         Time.timeScale = 0f;
         pause_ = true;
    }



    void Update()
    {
        //if (pause_) Resume();
        //else Pause(); 
    }
}
