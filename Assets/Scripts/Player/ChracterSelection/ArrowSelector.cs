using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSelector : MonoBehaviour
{
    public GameObject[] objs;
    public int currentObjIndex;
    void Start()
    {
        currentObjIndex = PlayerPrefs.GetInt("SelectedBall", 0);
        foreach (GameObject ball in objs)
            ball.SetActive(false);

        objs[currentObjIndex].SetActive(true);


    }
}
