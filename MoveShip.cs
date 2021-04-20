using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public Rigidbody boatRigid;
    public GameObject boat;
    public bool anchordeployed;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        //boatRigid = GetComponent<Rigidbody>();
        anchordeployed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (anchordeployed == false)
        {
            var step = boat.transform.forward.normalized * speed * Time.deltaTime;
        }
    }

    public void anchorUp()
    {
        anchordeployed = false;
    }

    public void anchorDown()
    {
        anchordeployed = true;
    }
}
