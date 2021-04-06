using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    //Called when game is paused
    public void PauseEvent() {
        if(gamePaused) { //If game is paused, resume
            Resume();
        } else {         //If game is not paused, pause
            Pause();
        }
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit() {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
