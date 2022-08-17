using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Gate : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private Material blueMaterial;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Material redMaterial;
    [SerializeField] private TMP_Text _gateText;
    [SerializeField] private bool start;
    private MeshRenderer _meshRenderer;
    private int gateNumber;
    public string gateOperator;
    public int newArrowCount;
    public int arrowDisplay;
    public Text ArrowsText;
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        AssignOperator();
        AssignNumber();
        AssignText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            GateOperation();
            Destroy(this.gameObject); 
        }
    }
    private void AssignOperator()
    {
        if (start)
        {
            return;
        }

        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                gateOperator = "+";
                _meshRenderer.material = blueMaterial;
                break;
            case 1:
                gateOperator = "-";
                _meshRenderer.material = redMaterial;
                break;
            case 2:
                gateOperator = "*";
                _meshRenderer.material = blueMaterial;
                break;
            case 3:
                gateOperator = "/";
                _meshRenderer.material = redMaterial;
                break;
        }
    }
    private void AssignNumber()
    {
        if (gateOperator == "*" || gateOperator == "/")
        {
            gateNumber = Random.Range(1, 4);
        }
        else
        {
            gateNumber = Random.Range(1, 10);
        }
    }

    private void AssignText()
    {
        _gateText.text = gateOperator + gateNumber;
    }

   
    private void GateOperation()
    {
        int arrowCount = player.transform.childCount;
        
        int arrowToInstantiate;
        int arrowToDestroy;
        Debug.Log("There are ," + arrowCount + " child objects in arrow stack");
        if (gateOperator == "*")
        {
            newArrowCount = arrowCount * gateNumber;
            arrowToInstantiate = newArrowCount - arrowCount;
            for (int i = 0; i < arrowToInstantiate; i++)
            {
                Instantiate(arrowPrefab, player.transform);
            }

            arrowDisplay = newArrowCount;
            ArrowsText.text = arrowDisplay.ToString();
            Debug.Log("New arrow count is :" + newArrowCount);
           // PlayerPrefs.SetInt("ArrowsCollected", PlayerPrefs.GetInt("ArrowsCollected", 0) + newArrowCount);
            Debug.Log("ArrowsColledted" + PlayerPrefs.GetInt("ArrowsCollected"));
        }
        else if (gateOperator == "/")
        {
            newArrowCount = arrowCount / gateNumber;
            arrowToDestroy = arrowCount - newArrowCount;
            for (int i = 0; i < arrowToDestroy; i++)
            {
                Destroy(player.transform.GetChild(i).gameObject);
            }

            arrowDisplay = newArrowCount;
           // ArrowsText.text = arrowDisplay.ToString();
            Debug.Log("New arrow count is :" + newArrowCount);
           // PlayerPrefs.SetInt("ArrowsCollected", PlayerPrefs.GetInt("ArrowsCollected", 0) + newArrowCount);
            Debug.Log("ArrowsColledted" + PlayerPrefs.GetInt("ArrowsCollected"));
        }
        else if (gateOperator == "+")
        {
            newArrowCount = arrowCount + gateNumber;
            arrowToInstantiate = newArrowCount - arrowCount;
            for (int i = 0; i < arrowToInstantiate; i++)
            {
                Instantiate(arrowPrefab, player.transform);
            }

            arrowDisplay = newArrowCount;
            //ArrowsText.text = arrowDisplay.ToString();
            Debug.Log("New arrow count is :" + newArrowCount);

            //PlayerPrefs.SetInt("ArrowsCollected", PlayerPrefs.GetInt("ArrowsCollected", 0) + newArrowCount);
            Debug.Log("ArrowsColledted" + PlayerPrefs.GetInt("ArrowsCollected"));
        }
        else if (gateOperator == "-")
        {
            newArrowCount = arrowCount - gateNumber;
            arrowToDestroy = arrowCount - newArrowCount;
            for (int i = 0; i < arrowToDestroy; i++)
            {
                Destroy(player.transform.GetChild(i).gameObject);
            }

            arrowDisplay = newArrowCount;
           // ArrowsText.text = arrowDisplay.ToString();
            Debug.Log("New arrow count is :" + newArrowCount);
           // PlayerPrefs.SetInt("ArrowsCollected", PlayerPrefs.GetInt("ArrowsCollected", 0)  + newArrowCount);
            Debug.Log("ArrowsColledted"+ PlayerPrefs.GetInt("ArrowsCollected"));
        }

     
    }
    private void Update()
    {
        
       /* if (newArrowCount > PlayerPrefs.GetInt("ArrowsCollected", 0))
        {
            PlayerPrefs.SetInt("ArrowsCollected", 0 + newArrowCount);
        }  
        PlayerPrefs.SetInt("ArrowShop",arrowToSave);*/
    }
}