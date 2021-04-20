using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallReload : MonoBehaviour
{

    public shoot_object sO;
    public string cannonBallName; 
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CannonBallTag: " + collision.collider.gameObject.tag);
       
        if(collision.collider.gameObject.tag == "Reloadable")
        {
            if(sO.reloaded == false)
            {
                Debug.Log("Reload Called");
                sO.reloaded = true; 
                StartCoroutine(sO.Reload());
                Destroy(collision.gameObject); 
            }         
        }
        else
        {
            Debug.Log("Tag not detected"); 
        }
    }
}
