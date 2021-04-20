using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ship_controls : MonoBehaviour
{
    //Steering Objects
    public Transform steeringWheel;
    public GameObject Boat;
    public Rigidbody BoatRigidBody; 
    public TextMeshPro debug;
    public float currentSteeringWheelRotation = 0; 
    //Dampeners
    public float turnDampening;
    public GameObject Player;
    public bool anchorDeployed; 

    // Start is called before the first frame update
    void Start()
    {
        anchorDeployed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (anchorDeployed == false)
        {
            turnShip();           
        }
        currentSteeringWheelRotation = steeringWheel.transform.eulerAngles.y;
    }

    private void turnShip()
    {
        var turn = -transform.rotation.eulerAngles.z;

        debug.SetText("Angle: " + turn); 
        if(turn < -350)
        {
            turn = turn + 360; 
        }

        BoatRigidBody.MoveRotation(Quaternion.RotateTowards(Boat.transform.rotation, Quaternion.Euler(0, turn, 0), Time.deltaTime * turnDampening));
    }

    public void AnchorUp()
    {
        anchorDeployed = false;
        Player.transform.parent = Boat.transform;
    }

    public void AnchorDown()
    {
        anchorDeployed = true; 
        Player.transform.parent = null;
    }
}
