using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Contact : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject tempEffect = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
        Destroy(tempEffect, 5);
        Destroy(gameObject);
    }
}
