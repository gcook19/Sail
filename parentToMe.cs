using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentToMe : MonoBehaviour
{
    public string playerName;
    private Transform ogPlayerParent;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == playerName)
        {
            ogPlayerParent = collision.collider.transform.parent; 
            collision.collider.transform.parent = gameObject.transform;
            Debug.Log("Parented");
        }
    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name == playerName)
        {
            Debug.Log("Unparented"); 
            collision.collider.transform.parent = ogPlayerParent; 
        }
    }*/ 
}
