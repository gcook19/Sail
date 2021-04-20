using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standingOn : MonoBehaviour
{
    public GameObject player;
    public GameObject ship;

    public float distance;

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, ship.transform.position);

        if(distance < 10f)
        {
            gameObject.transform.parent = ship.transform; 
        }

        if( distance > 5f)
        {
            gameObject.transform.parent = null; 
        }

        string temp = player.transform.parent.name;
        Debug.Log("Parent Name: " + temp);
    }
}
