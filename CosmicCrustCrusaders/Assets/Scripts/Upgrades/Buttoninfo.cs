using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttoninfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public Text StockTxt;
    public GameObject ShopManager; 
    

    // Update is called once per frame
    void Update()
    {


        PriceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = "Purchased: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
        StockTxt.text = "Stock: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[4, ItemID].ToString();



    }
}
