using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPurchase : MonoBehaviour
{

    public Text ItemDisplay_1;
    public Text ItemDisplay_2;
    public Text ItemDisplay_3;

    public string purchaseName;


    // 아이템 보유 갯수
    public int num_1;
    public int num_2;
    public int num_3;


    // 아이템 구매 비용
    public int itemCost_1 = 10;

    public int itemCost_2 = 50;

    public int itemCost_3 = 100;



    public void Start()
    {

        DataController.DataInstance.LoadPurchaseButton(this);
        UpdateDisplay();

    }


    // 아이템1 구매 
    public void PurchaseItem_1()
    {
        if(DataController.DataInstance.bell >= itemCost_1)
        {
            DataController.DataInstance.bell -= itemCost_1;
            num_1++;
            UpdateDisplay();
            DataController.DataInstance.SavePurchaseButton(this);
        }
    }

    // 아이템2 구매 
    public void PurchaseItem_2()
    {
        if (DataController.DataInstance.bell >= itemCost_2)
        {
            DataController.DataInstance.bell -= itemCost_2;
            num_2++;
            UpdateDisplay();
            DataController.DataInstance.SavePurchaseButton(this);
        }
    }


    // 아이템3 구매 
    public void PurchaseItem_3()
    {
        if (DataController.DataInstance.bell >= itemCost_3)
        {
            DataController.DataInstance.bell -= itemCost_3;
            num_3++;
            UpdateDisplay();
            DataController.DataInstance.SavePurchaseButton(this);
        }
    }


    // 아이템 보유량 디스플레이
    public void UpdateDisplay()
    {
        ItemDisplay_1.text = purchaseName + "보유 중: " + num_1;
        ItemDisplay_2.text = purchaseName + "보유 중: " + num_2;
        ItemDisplay_3.text = purchaseName + "보유 중: " + num_3;

    }
}
