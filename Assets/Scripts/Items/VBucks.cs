using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VBucks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(40 * Time.deltaTime, 20 * Time.deltaTime, 20 * Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfVbucks += 1;
            PlayerPrefs.SetInt("numberOfVbucks", PlayerPrefs.GetInt("numberOfVbucks", 0) + 1);
            Destroy(gameObject);
            Debug.Log("COInnnnn");
        }
    }
}
