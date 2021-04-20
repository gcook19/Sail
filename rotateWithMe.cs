using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWithMe : MonoBehaviour
{
    public GameObject wheel;

    private void Update()
    {
        float otherY = wheel.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, 0, otherY);
    }
}
