using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBelowMe : MonoBehaviour
{
    RaycastHit hit;

    private void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << 8;

        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0,-1,0)), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0,-1,0)) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
