using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BNG
{
    public class ReloadOnCollision : MonoBehaviour
    {
        [SerializeField] private pistolManager pM;
        [SerializeField] private string reloadable_Tag; 

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Pistol Front Collider Tag: " + collision.gameObject.tag);
          

            if(collision.gameObject.tag == reloadable_Tag)
            {
                pM.Reload_Pistol();
                Debug.Log("Bullet in Chamber");
                Destroy(collision.gameObject); 
            }
        }
    }
}
