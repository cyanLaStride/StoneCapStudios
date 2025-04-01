using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttoninfo : MonoBehaviour, IPointerEnterHandler
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public Text StockTxt;
    public GameObject ShopManager;
    public GameObject ToolTip;
    public GameObject NotToolTip1;
    public GameObject NotToolTip2;

    // Update is called once per frame
    void Update()
    {

        if (PriceTxt != null)
        {
            PriceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
            QuantityTxt.text = "Purchased: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
            StockTxt.text = "Stock: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[4, ItemID].ToString();
        }
        



    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTip.SetActive(true);
        NotToolTip1.SetActive(false);
        NotToolTip2.SetActive(false);
    }
}
