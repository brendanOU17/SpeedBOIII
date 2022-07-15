using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject[] ballModels;
    public int currentBallIndex;
    void Start()
    {
        currentBallIndex = PlayerPrefs.GetInt("SelectedBall", 0); 
        foreach (GameObject ball in ballModels)
         ball.SetActive(false);

        ballModels[currentBallIndex].SetActive(true);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        ballModels[currentBallIndex].SetActive(false);
        currentBallIndex++;
        if(currentBallIndex == ballModels.Length)
            currentBallIndex=0;
        ballModels[currentBallIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedBall", currentBallIndex);
    }

    public void Prev()
    {
        ballModels[currentBallIndex].SetActive(false);
        currentBallIndex--;
        if (currentBallIndex == -1)
            currentBallIndex = ballModels.Length -1;
        ballModels[currentBallIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedBall", currentBallIndex);
    }
}
