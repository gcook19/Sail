using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData {
    public int coins;

    public playerData(player ply)
    {
        coins = ply.totalCoins;
    }
}
