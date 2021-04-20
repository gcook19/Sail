using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics; 

public class SpawnSkeletons : MonoBehaviour
{

    public GameObject[] AIObjects; 
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < AIObjects.Length; i++)
        {
            AIObjects[i].SetActive(false); 
        }
    }

    // Update is called once per frame
    public void spawnAI()
    {
        for(int i = 0; i < AIObjects.Length; i++)
        {
            AIObjects[i].SetActive(true); 
        }
        Debug.Log("AI spawned");
        Analytics.CustomEvent("Treasure Hunt Complete"); 
    }
}
