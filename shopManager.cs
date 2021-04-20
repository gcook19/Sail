using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class shopManager : MonoBehaviour
{
    public GameObject moneyObject;
    public string purchaseTagString;
    private int costOfItems = 0;
    public Transform payOutLocation;
    public player playerScript;
    public List<GameObject> stuffToSell; 
    public TextMeshPro showPrice; 

    void Start()
    {
        moneyObject.SetActive(false);
        showPrice.SetText("SELL\n\nHERE"); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == purchaseTagString)
        {
            SetUpShop(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == purchaseTagString)
        {
            stuffToSell.Remove(collision.gameObject);
            itemDetails iD = collision.gameObject.GetComponentInChildren<itemDetails>();
            costOfItems -= iD.itemValue;
            showPrice.SetText("Price:\n\n{0}", costOfItems);
        }

        if(stuffToSell.Count == 0)
        {
            moneyObject.SetActive(false); 
        }
    }

    private void SetUpShop(Collision col)
    {
        //find object in children
        itemDetails iD = col.gameObject.GetComponentInChildren<itemDetails>();
        costOfItems += iD.itemValue;
        moneyObject.SetActive(true);
        showPrice.SetText("Price:\n\n{0}", costOfItems); 
        moneyObject.transform.position = payOutLocation.transform.position;
        stuffToSell.Add(col.gameObject);
    }


    public void GiveMoney()
    {
        playerScript.AddCoins(costOfItems);
        moneyObject.SetActive(false);

        foreach(var item in stuffToSell)
        {
            Destroy(item); 
        }

        stuffToSell.Clear(); 
        showPrice.SetText("SELL\n\nHERE");
        playerScript.SavePlayer();
        costOfItems = 0; 
    }
}
