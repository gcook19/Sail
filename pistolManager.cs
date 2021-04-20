using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class pistolManager : MonoBehaviour
    {
        [Header("General Stuff")]
        public Rigidbody projectile;
        public float projectile_Speed;
        public Transform end_of_barrel;
        public Collider reload_Collider;
        public Grabber RH_Grabber;
        public Grabber LH_Grabber;
        public Grabbable pistol_Grabbable; 

        [Header("Debug")]
        [SerializeField] private bool reloaded;
        [SerializeField] private bool cocked; 
        
        //SFX
        [Header("Effects")]
        //private AudioSource fireSFX;
        ///public AudioSource reloadSFX;
        //public AudioSource cockedSFX; 
        public GameObject muzzleFlash;
        public cock_On_Collision cocScript; 

        // Start is called before the first frame update
        void Start()
        {
            reload_Collider.enabled = true;
            reloaded = false;
            cocked = false; 
        }

        // Update is called once per frame
        void Update()
        {
            if(reloaded == true)
            {
                if (cocked == true)
                {
                    if (RH_Grabber.HeldGrabbable == this.pistol_Grabbable)
                    {
                        if (InputBridge.Instance.RightTriggerDown)
                        {
                            firePistol();
                        }
                    }
                    else if (LH_Grabber.HeldGrabbable == this.pistol_Grabbable)
                    {
                        if (InputBridge.Instance.LeftTriggerDown)
                        {
                            firePistol();
                        }
                    }
                }
            }
            
        }

        private void firePistol()
        {
            Debug.Log("Trigger Pulled");
            reloaded = false;
            cocked = false;
            //fireSFX.Play();

            Debug.Log(end_of_barrel.transform.position.ToString() + "<-End of Barrel Transform"); 
            GameObject muzzle_clone = Instantiate(muzzleFlash, end_of_barrel.transform.position, end_of_barrel.transform.rotation);
            //muzzle_clone.transform.Rotate(0, -90, 0, Space.World);
            Rigidbody projectile_clone = (Rigidbody)Instantiate(projectile, end_of_barrel.position, end_of_barrel.rotation);

            projectile_clone.velocity = end_of_barrel.forward * projectile_Speed;

            Destroy(muzzle_clone, 5);

            reload_Collider.enabled = true;
            cocScript.hammerPositionReset(); 
        }

        public void Reload_Pistol()
        {
            reloaded = true;
            reload_Collider.enabled = false;
            //reloadSFX.Play(); 
        }

        public void cock_Pistol()
        {
            cocked = true;
            //cockedSFX.Play(); 
        }
    }


}
