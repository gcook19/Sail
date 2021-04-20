using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderShow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("name:" + collision.gameObject.name);
    }
}
