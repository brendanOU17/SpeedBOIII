using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject pauseButton;
    public void Replay()
    {
        SceneManager.LoadScene("Gameplay"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
