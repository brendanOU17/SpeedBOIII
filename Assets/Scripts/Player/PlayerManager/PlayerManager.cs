using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameoverPanel;
    public GameObject pauseButton;
    public static int numberOfVbucks;
    public Text vBucksText;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            pauseButton.SetActive(false);
            gameoverPanel.SetActive(true);
        }
        vBucksText.text = "Vbucks" + numberOfVbucks;
    }
}
