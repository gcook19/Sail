using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BNG
{
    public class moveForw : MonoBehaviour
    {

        private float speed;
        public float default_Speed;
        private float newSpeed;
        public GameObject sail1;
        public GameObject sail2;
        public float speedUp_down;

        //public GameObject Player;
        public Transform anchorStand; 

        public Transform wheel;
        public Rigidbody rb;
        public GameObject boat;
        private float orig_Rotation;
        public Transform target;
        public Transform left;
        public Transform right;
        private Vector3 normalizedDirection;
        public float turnDampener;
        public bool anchorDeployed;

        public bool Testing; 

        private void Start()
        {
            anchorDeployed = true;
            //Player.transform.parent = null;
            speed = 0;
            normalizedDirection = (target.position - transform.position).normalized;
            wheel.transform.rotation = Quaternion.Euler(0, 0, 0);
            sail1.SetActive(false);
            sail2.SetActive(false);
        }

       // private void OnLevelWasLoaded(int level)
        //{
         //   orig_Rotation = wheel.transform.rotation.eulerAngles.z;
        //}

        void Update()
        {
            if (Testing == true)
            {
                anchorUp();
            }

            //rb.velocity = normalizedDirection * Time.deltaTime * speed;
            
            normalizedDirection = (target.position - transform.position).normalized;
            float turn = wheel.transform.rotation.eulerAngles.z;

            if (anchorDeployed == false)
            {
                //rb.MovePosition(target.transform.position + normalizedDirection * Time.deltaTime * speed);
                //Right Turn
                if (turn < 358 && turn > 185)
                {
                    //float temp = turn - 185;

                    rb.MoveRotation(Quaternion.RotateTowards(rb.transform.rotation, right.transform.rotation, Time.deltaTime * turnDampener));
                }


                //Left Turn
                if (turn > 1 && turn < 175)
                {
                    rb.MoveRotation(Quaternion.RotateTowards(rb.transform.rotation, left.transform.rotation, Time.deltaTime * turnDampener));
                }
            }
        }

        public void anchorUp()
        {

            //PlayerTeleport teleporter = FindObjectOfType<PlayerTeleport>();
            //LocomotionManager locochanger = FindObjectOfType<LocomotionManager>();
            rb.velocity = normalizedDirection * Time.deltaTime * speed;

            int loco_type_temp = PlayerPrefs.GetInt("LocomotionSelection");

            if (loco_type_temp == 1)
            {

                //locochanger.ChangeLocomotion(LocomotionType.Teleport, true);
                //locochanger.ChangeLocomotion(LocomotionType.SmoothLocomotion, true); 
            }

            //teleporter.TeleportPlayerToTransform(anchorStand); 

            if (anchorDeployed == true)
            {
                //Player.transform.parent = boat.transform;
                speed = default_Speed;
                anchorDeployed = false;

                if (sail1 == isActiveAndEnabled)
                {
                    speed = speed + speedUp_down;
                }

                if (sail2 == isActiveAndEnabled)
                {
                    speed = speed + speedUp_down;
                }
            }
            rb.velocity = normalizedDirection * Time.deltaTime * speed;
            //temp.enabled = true; 
        }

        public void anchorDown()
        {
            if (anchorDeployed == false)
            {
                speed = 0;
                anchorDeployed = true;

                //Player.transform.parent = null;
            }
        }


        public void actiivatesail1()
        {
            sail1.SetActive(true);
            if (anchorDeployed == false)
            {
                speed = speed + speedUp_down;
            }
        }

        public void deactivateSail1()
        {
            sail1.SetActive(false);
            if (anchorDeployed == false)
            {
                speed = speed - speedUp_down;
            }
        }

        public void actiivatesail2()
        {
            sail2.SetActive(true);

            if (anchorDeployed == false)
            {
                speed = speed + speedUp_down;
            }
        }

        public void deactivateSail2()
        {
            sail2.SetActive(false);
            if (anchorDeployed == false)
            {
                speed = speed - speedUp_down;
            }
        }

    }
}
