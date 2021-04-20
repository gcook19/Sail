using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BNG
{

    public class VRBoatControl : MonoBehaviour
    {
        [Header("Player Info")]
        public BNGPlayerController BNGPC; 
        public GameObject player;
        Transform defaultPlayerTransform;
        public Transform cameraPosition;
        public int breakFromBoatDistance;
        bool isParented; 

        [Header("Boat Info")]
        public GameObject boatGO; 
        public Rigidbody boatRB;        
        private float startY;
        public int boatLayerInt; 

        [Header("Turning")]
        public GameObject wheel;
        public SteeringWheel steeringWheelScript;
        private float originalWheelRoation; 
        public float turnThrustPub; 
        
        [Header("Speed")]
        public float forwardThrust;
        public float maxSpeed;
        public float addSpeed; 
        public GameObject sailsUp;
        public GameObject sailsDown;
        private bool areSailsUp = false;
        public bool isDriving = false;
       

        

        private void Start()
        { 
            defaultPlayerTransform = player.transform.parent;
            startY = gameObject.transform.position.y;
            areSailsUp = true;
            sailsUp.SetActive(true);
            sailsDown.SetActive(false); 
            StartCoroutine(waitToSetup()); 
        }
        IEnumerator waitToSetup()
        {
            yield return new WaitForSeconds(1);
            originalWheelRoation = steeringWheelScript.Angle; 
        }

        public bool IsPlayerCloseToBoat()
        {
            return Vector3.Distance(gameObject.transform.position, cameraPosition.transform.position) < breakFromBoatDistance;
        }

        public void SetDriving(bool isDriving)
        {
            this.isDriving = isDriving;

            if (isDriving)
            {
                //player.gameObject.transform.SetParent(boatRB.gameObject.transform); 
                Debug.Log("Parented To Boat");
                //isParented = true; 
            }
        }

        private void Update()
        {
            shouldIDepartent();
            
            if (isDriving)
            {

                float turn = steeringWheelScript.Angle;
                //Debug.Log("turn:" + turn); 
                float turnThrust = 0;

                if (turn > (originalWheelRoation + 5) && turn < steeringWheelScript.MaxAngle )
                {


                    turnThrust = (-1 * calculateTurnThrust(turn));
                    Debug.Log("Turning Left");
                }

                if (turn < (originalWheelRoation - 5)  && turn > steeringWheelScript.MinAngle )
                {
                    turnThrust = calculateTurnThrust(turn); 
                    Debug.Log("Turning Right");
                }

                if(areSailsUp == true)
                {
                    turnThrust *= 2; 
                }

                boatRB.AddRelativeTorque(Vector3.up * turnThrust);
            }
           
            Vector3 newPosition = gameObject.transform.position;
            newPosition.y = startY + Mathf.Sin(Time.timeSinceLevelLoad * 2) / 8;
            gameObject.transform.position = newPosition;
        }

        private void isStuck()
        {
            if(boatRB.velocity.magnitude <= 0.01f)
            {
                boatRB.transform.Rotate(boatRB.transform.rotation.x, boatRB.transform.rotation.y + 15f, boatRB.transform.rotation.z);
                Debug.Log("Trying to get Unstuck"); 
            }
        }

        private float calculateTurnThrust(float turnAngle)
        {
            float tempThrust;
            if (turnAngle > originalWheelRoation)
            {   
                //right turn
                tempThrust = ((turnAngle) / steeringWheelScript.MaxAngle) * turnThrustPub;
                Debug.Log("Temp Turn Thrust:" + tempThrust);
                return tempThrust;
            }
            else if (turnAngle < originalWheelRoation)
            {
                //left turn
                tempThrust = ((turnAngle * -1) / steeringWheelScript.MaxAngle) * turnThrustPub;
                Debug.Log("Temp Turn Thrust:" + tempThrust);
                return tempThrust;
            }
            else {
                return 0.0f;
                Debug.Log("Angle not recognized"); 
            }
        }

        private void FixedUpdate()
        {
            if (isDriving)
            {
                boatRB.AddForce(gameObject.transform.forward * forwardThrust);
                boatRB.velocity = Vector3.ClampMagnitude(boatRB.velocity, maxSpeed);
                shouldIDepartent(); 
            }
        }
        
        public void shouldIDepartent()
        {

            //NEEDS TO BE FIXED!!!

            int temp = BNGPC.LayerInt;
            //Debug.Log("Temp Layer Reading:" + temp); 

            if(temp != boatLayerInt && isParented == true)
            {
                DeparentPlayer(); 
            }

            if(temp == boatLayerInt && isParented == false)
            {
                player.gameObject.transform.SetParent(boatRB.gameObject.transform);
                isParented = true; 
            }
           
        }

        private void DeparentPlayer()
        {
            if(defaultPlayerTransform == null)
            {
                player.transform.SetParent(null);
            }
            else
            {
                player.transform.SetParent(defaultPlayerTransform.transform);
            }
           //player.transform.parent = defaultPlayerTransform.transform;
           Debug.Log("Deparented");
           isParented = false; 
        }
        

        public void putSailsUp()
        {
            if (areSailsUp == true)
            {
                //do nothing sails are already up
            }
            else
            {
                areSailsUp = true;
                sailsUp.SetActive(true);
                sailsDown.SetActive(false);
                maxSpeed -= addSpeed;
                forwardThrust -= addSpeed;
                //areSailsUp = true;
            }
        }

        public void putsailsDown()
        {
            if (areSailsUp == false)
            {
                //do nothing sails are already down
            }
            else
            {
                areSailsUp = false;
                sailsUp.SetActive(false);
                sailsDown.SetActive(true);
                maxSpeed += addSpeed;
                forwardThrust += addSpeed;
                //areSailsUp = false; 
            }
        }
    }
}
