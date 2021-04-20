using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public GameObject[] all_Loot_Options;
    public Transform spawnLocation;
    // Start is called before the first frame update

    private void OnEnable()
    {
        spawnLoot();
    }

    public void spawnLoot()
    {
        int selection = Random.Range(0, all_Loot_Options.Length);

        Instantiate(all_Loot_Options[selection], spawnLocation.transform.position, spawnLocation.transform.rotation);
    }


    public void DeactivateSelf()
    {
        gameObject.SetActive(false); 
    }
}
