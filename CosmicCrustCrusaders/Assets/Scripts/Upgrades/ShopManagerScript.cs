using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    //public float coins;
    public Text CoinsTXT;


    private GameManager gameManager;

    [SerializeField]
    private GameObject IgnateaBuyButton;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //coins = gameManager.CoinCount;
        CoinsTXT.text = "Coins: " + gameManager.CoinCount.ToString();

        //ID's
        shopItems[1, 1] = 1; // hook
        shopItems[1, 2] = 2; // propellor
        shopItems[1, 3] = 3; // boosters
        shopItems[1, 4] = 4; //  unused


        //Price
        shopItems[2, 1] = 80;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 35;
        shopItems[2, 4] = 50;


        //Quantity 
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        if (gameManager.upgGrapplingHookUnlock)
        {
            shopItems[3, 1] = 1;
        }
        if (gameManager.upgPropellorUnlock)
        {
            shopItems[3, 2] = 1;
        }
        if (gameManager.upgBuddyBoostersUnlock)
        {
            shopItems[3, 3] = 1;
        }
        if (gameManager.lvlIgnateaUnlock)
        {
            shopItems[3, 4] = 1;
        }

        // Stock available
        shopItems[4, 1] = 1;
        shopItems[4, 2] = 1;
        shopItems[4, 3] = 1;
        shopItems[4, 4] = 1;
        if (gameManager.upgGrapplingHookUnlock)
        {
            shopItems[4, 1] = 0;
        }
        if (gameManager.upgPropellorUnlock)
        {
            shopItems[4, 2] = 0;
        }
        if (gameManager.upgBuddyBoostersUnlock)
        {
            shopItems[4, 3] = 0;
        }
        if (gameManager.lvlIgnateaUnlock)
        {
            shopItems[4, 4] = 0;
            IgnateaBuyButton.SetActive(false);
        }

    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        int itemID = ButtonRef.GetComponent<Buttoninfo>().ItemID;

        if (shopItems[4, itemID] > 0 && gameManager.CoinCount >= shopItems[2, itemID])
        {
            if (itemID == 1)
            {
                gameManager.upgGrapplingHookUnlock = true;
            }
            else if (itemID == 2)
            {
                gameManager.upgPropellorUnlock = true;
            }
            else if (itemID == 3)
            {
                gameManager.upgBuddyBoostersUnlock = true;
            }
            else if (itemID == 4)
            {
                gameManager.lvlIgnateaUnlock = true;
                IgnateaBuyButton.SetActive(false);
            }
            gameManager.CoinCount -= shopItems[2, itemID];
            shopItems[3, itemID]++; // Increase purchased quantity
            shopItems[4, itemID]--; // Decrease stock
            CoinsTXT.text = "Coins: " + gameManager.CoinCount.ToString();
            ButtonRef.GetComponent<Buttoninfo>().QuantityTxt.text = "Purchased: " + shopItems[3, itemID].ToString();
            ButtonRef.GetComponent<Buttoninfo>().StockTxt.text = "Stock: " + shopItems[4, itemID].ToString();
        }
        else if (shopItems[4, itemID] <= 0)
        {
            Debug.Log("Out of stock!");
        }
        else if (gameManager.CoinCount < shopItems[2, itemID])
        {
            Debug.Log("Not enough coins!");
        }





    }
}
