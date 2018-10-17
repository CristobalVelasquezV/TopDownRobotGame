using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool isGamePaused = false;
    public GameObject pausePanel;

	void Update () {
        if (Input.GetButtonDown("Pause")) {
            if (isGamePaused)
            {
                unPause();
            }
            else {
                Pause();
            }
        }
	}

    private void Pause()
    {
        isGamePaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void unPause()
    {
        isGamePaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void goToMenu() {
        unPause();
        SceneManager.LoadScene(0);
    }

    public void guitGame() {
        Application.Quit();
    }
}
