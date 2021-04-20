using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BNG
{
    public class loadPrefs : MonoBehaviour
    {
        public PlayerRotation rotation; 

        // Start is called before the first frame update
        void Start()
        {
            rotation = FindObjectOfType<PlayerRotation>(); 

            int turn = PlayerPrefs.GetInt("TurnSelection");

            if(turn == 0)
            {
                rotation.RotationType = RotationMechanic.Snap;
            }
            else
            {
                rotation.RotationType = RotationMechanic.Smooth; 
            }
        }

        // Update is called once per frame
    }
}
