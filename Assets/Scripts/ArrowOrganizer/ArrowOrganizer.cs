using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowOrganizer : MonoBehaviour
{
    [SerializeField] private float rx = 2f; // horizontal radius
    [SerializeField] private float ry = 1.5f; // vertical radius
    public Text ArrowsText;
    public int arrowCount;
    private void Update()
    {
        ArrowPositionUpdater();
    }

    private void ArrowPositionUpdater()
    {
        arrowCount = transform.childCount;

        if(arrowCount == 0)
        {
            PlayerManager.gameOver = true;
        }
        float angleSelection = Mathf.PI * 2f / arrowCount;
        ArrowsText.text = arrowCount.ToString();
        for (int i = 0; i < arrowCount; i++)
        {
            Transform child = transform.GetChild(i);
            float angle = i * angleSelection;
            ry = Mathf.Sqrt(arrowCount) / arrowCount;
            Vector3 arrowPosition = transform.position + new Vector3(rx * Mathf.Cos(angle),
                ry * Mathf.Sin(angle) * Mathf.Sqrt(i),
                0f);
            if (i == 0)
            {
                arrowPosition = transform.position;
            }

            child.position = arrowPosition;
        }


    }
}