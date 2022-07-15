using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelector : MonoBehaviour
{
    public GameObject[] balls;
    public int currentBallIndex;
    void Start()
    {
        currentBallIndex = PlayerPrefs.GetInt("SelectedBall", 0);
        foreach (GameObject ball in balls)
            ball.SetActive(false);

        balls[currentBallIndex].SetActive(true);


    }
}
