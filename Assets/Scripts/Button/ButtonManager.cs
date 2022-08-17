using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject pauseButton;
    public TextMeshProUGUI highscoreText;
    [SerializeField] private SoundData buttonSFX;


    private void Update()
    {
        highscoreText.text = "Total Arrows Earned: \n" + PlayerPrefs.GetInt("ArrowsCollected", 0);
        //vBucksText.text = PlayerPrefs.GetInt("ArrowShop", 0).ToString();
    }
    public void Replay()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        SceneManager.LoadScene("Gameplay"); 
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        Application.Quit();
    }

    public void MainMenu()
    {
        
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Pause()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void StartGame()
    {
        SoundManager.instance.PlaySFX(buttonSFX, "ButtonSFX");
        SceneManager.LoadScene("Gameplay");
    }
}
