using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerUpgrade : MonoBehaviour
{


    public Text UpgradeDisplayer;

    public string upgradeName;


    //클릭 당 획득량
    public int bellByUpgrade;
    public int startBellByUpgrade;

    //레벨
    public int level = 1;


    //구매 비용
    public int currentCost;
    public int startCurrentCost = 1;

    // 업그레이드 할 때마다 구매 비용 증가
    public float upgradePow = 1.07f;
    public float costPow = 3.14f;


    void Start()
    {
        DataController.DataInstance.LoadUpgradeButton(this);
        UpdateDisplay();

    }


    // 클릭 당 획득 벨 업그레이드 구매
    public void PurchaseUpgrade()
    {
        if(DataController.DataInstance.bell >= currentCost)
        {
            DataController.DataInstance.bell -= currentCost;
            level++;
            DataController.DataInstance.bellPerClick += bellByUpgrade;

            UpdateUpgrade();
            UpdateDisplay();
            DataController.DataInstance.SaveUpgradeButton(this);
        }
    }


    // 업그레이드 갱신(클릭 당 벨 획득, 구매비용)
    public void UpdateUpgrade()
    {
        bellByUpgrade = startBellByUpgrade *(int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }


    // 클릭 당 벨 획득 디스플레이
    public void UpdateDisplay()
    {
        UpgradeDisplayer.text = upgradeName + "\n 레벨: " + level + "\n비용: " + currentCost;
            
    }
}
