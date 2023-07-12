using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenu;
    public GameObject panel;
    public GameObject settingsMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ShowSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        gameIsPaused = true;
    }

    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}



