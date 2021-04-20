using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_object : MonoBehaviour
{

    public Rigidbody projectile;
    public GameObject trigger;
    public float projectile_Speed;
    public Transform end_of_barrel;
    
    public GameObject muzzleFlash;
    public bool test;

    public int reload_time;
    public bool reloaded;
    public Collider reloadCollider; 

    //SFX
    private AudioSource fireSFX;
    public AudioSource reloadSFX; 

    private void Start()
    {
        fireSFX = GetComponent<AudioSource>();
        reloaded = false;
        trigger.SetActive(false);
        reloadCollider.enabled = true; 

        if (test == true)
        {
            Trigger_Pulled();
        }
    }

    private void Update()
    {
        if(test == true)
        {
            if(reloaded == false)
            {
                StartCoroutine(Reload()); 
            }
            else
            {
                Trigger_Pulled(); 
            }
        }
                 
     }

    public void Trigger_Pulled()
    {
        if (reloaded == true)
        {
            Debug.Log("Trigger Pulled"); 
            reloaded = false; 
            fireSFX.Play();
            trigger.SetActive(false);

            GameObject muzzle_clone = (GameObject)Instantiate(muzzleFlash, end_of_barrel.transform.position, end_of_barrel.transform.rotation);
            muzzle_clone.transform.Rotate(0, -90, 0, Space.World);
            Rigidbody projectile_clone = (Rigidbody)Instantiate(projectile, end_of_barrel.position, end_of_barrel.rotation);

            projectile_clone.velocity = end_of_barrel.forward * projectile_Speed;

            Destroy(muzzle_clone, 5);

            reloadCollider.enabled = true; 
        }
    }

    public IEnumerator Reload()
    {
        reloadSFX.Play();
        reloadCollider.enabled = false; 
        yield return new WaitForSeconds(reload_time);
        trigger.SetActive(true);
    } 
}
