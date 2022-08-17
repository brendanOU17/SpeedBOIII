using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject[] ballModels;
    public int currentBallIndex;

    public ArrowBlueprint[] balls;
    public Button buyButton;
    void Start()
    {
        foreach(ArrowBlueprint ball in balls)
        {
            if (ball.price == 0)
                ball.isUnlocked = true;
            else
                ball.isUnlocked = PlayerPrefs.GetInt(ball.name, 0) == 0 ? false: true ;
        }
        currentBallIndex = PlayerPrefs.GetInt("SelectedBall", 0); 
        foreach (GameObject ball in ballModels)
         ball.SetActive(false);

        ballModels[currentBallIndex].SetActive(true);

       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void Next()
    {
        ballModels[currentBallIndex].SetActive(false);
        currentBallIndex++;
        if(currentBallIndex == ballModels.Length)
            currentBallIndex=0;
        ballModels[currentBallIndex].SetActive(true);
        ArrowBlueprint unlockBall = balls[currentBallIndex];
        if (!unlockBall.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedBall", currentBallIndex);
    }

    public void Prev()
    {
        ballModels[currentBallIndex].SetActive(false);
        currentBallIndex--;
        if (currentBallIndex == -1)
            currentBallIndex = ballModels.Length -1;
        ballModels[currentBallIndex].SetActive(true);
        ArrowBlueprint unlockBall = balls[currentBallIndex];
        if (!unlockBall.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedBall", currentBallIndex);
    }

    public void UnlockBall()
    {
        ArrowBlueprint unlockBall = balls[currentBallIndex];

        PlayerPrefs.SetInt(unlockBall.name, 1);
        PlayerPrefs.SetInt("SelectedBall", currentBallIndex);
        unlockBall.isUnlocked = true;
        PlayerPrefs.SetInt("ArrowsCollected", PlayerPrefs.GetInt("ArrowsCollected", 0)- unlockBall.price);
    }
    private void UpdateUI()
    {
        ArrowBlueprint updateBall = balls[currentBallIndex];
        if (updateBall.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text ="Buy- "+ updateBall.price;
            if (updateBall.price < PlayerPrefs.GetInt("ArrowsCollected", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable= false;
            }
        }
    } 
}
