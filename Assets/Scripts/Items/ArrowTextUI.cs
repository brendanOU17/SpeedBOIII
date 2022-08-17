using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowTextUI : MonoBehaviour
{
    public Text ArrowsText;
    public Gate getArrowvalue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(40 * Time.deltaTime, 20 * Time.deltaTime, 20 * Time.deltaTime);
        ArrowsText.text = getArrowvalue.arrowDisplay.ToString();
        Debug.Log(getArrowvalue.arrowDisplay.ToString());
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfVbucks += 1;
            PlayerPrefs.SetInt("numberOfVbucks", PlayerPrefs.GetInt("numberOfVbucks", 0) + 1);
            SoundManager.instance.PlaySFX(playerSFX, "PickUp");
            Destroy(gameObject);
            Debug.Log("COInnnnn");
        }
    }*/
}
