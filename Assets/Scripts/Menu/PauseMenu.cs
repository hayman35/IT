﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool gameIsPaused = false;

   public GameObject pauseMenuUI;


   private void Update() {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
           if(gameIsPaused)
           {
               Resume();
           } else{
               Pause();
           }
       }
   }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading");
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
