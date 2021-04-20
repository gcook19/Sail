using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireOnCollision : MonoBehaviour
{
    public string fireStickTag;
    public shoot_object sO; 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collider Tag: " + collision.collider.tag);
        Debug.Log("Collider True? :" + collision.collider.CompareTag(fireStickTag));

        if (collision.collider.CompareTag(fireStickTag) == true) 
        {
            Debug.Log("Collider works and function called"); 
            sO.Trigger_Pulled(); 
        }
    }
}
