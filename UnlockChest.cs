using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace BNG {
    public class UnlockChest : MonoBehaviour
    {
        public Grabbable TreasureChestGRAB1;
        public Grabbable TCGrab2;
        public GameObject Treasure; 
        public ParentConstraint PC; 

        private void Start()
        {
            TreasureChestGRAB1.enabled = false;
            TCGrab2.enabled = false;
            PC.constraintActive = true;
            Treasure.SetActive(false); 
        }

        public void unlockChest()
        {
            TreasureChestGRAB1.enabled = true;
            TCGrab2.enabled = true;
            PC.constraintActive = false;
            Treasure.SetActive(true); 
        }
    }
}
