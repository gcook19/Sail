using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class player : MonoBehaviour
{
    public TextMeshPro coinShow;
    public int totalCoins; 

    public void Start()
    {
        //LoadPlayer(); 
        StartCoroutine(waitToLoad()); 
    }

    IEnumerator waitToLoad()
    {
        yield return new WaitForSeconds(1);
        LoadPlayer(); 
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        playerData data = SaveSystem.LoadPlayer();

        totalCoins = data.coins;
        coinShow.SetText("Coins:{0}", totalCoins); 
    }
    
    public void AddCoins(int numCoins)
    {
        totalCoins += numCoins;
        coinShow.SetText("Coins: {0}", totalCoins);
    }

    public void removeCoins(int cost)
    {
        totalCoins -= cost;
        coinShow.SetText("Coins:{0}", totalCoins);
    }
}
