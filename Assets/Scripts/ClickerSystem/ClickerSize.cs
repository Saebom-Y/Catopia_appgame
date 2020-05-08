using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerSize : MonoBehaviour
{
    public Text SizeDisplayer;

    public string sizeName;

    public int level = 1;


    // 벨 수용량
    public int currentCapacity;
    public int startCapacity = 100;

    // 구매 비용
    public int currentCost = 1;

    public int startCurrentCost = 1;


    // 업그레이드 할 때마다 구매 비용 증가
    public float upgradePow = 1.07f;
    public float costPow = 3.14f;


   



    void Start()
    {
        DataController.DataInstance.LoadSizeButton(this);
        UpdateDisplay();
     
    }

    void Update()
    {
        CapacityBell();
    }



    // 벨 수용량 업그레이드 구매
    public void PurchaseSize()
    {
        if (DataController.DataInstance.bell >= currentCost)
        {
            DataController.DataInstance.bell -= currentCost;
            level++;     
            UpdateSize();       
            UpdateDisplay();
          
            DataController.DataInstance.SaveSizeButton(this);
        
        }
    }

    // 벨 수용량 
    public void CapacityBell()
    {
        if(DataController.DataInstance.bell >= currentCapacity)
        {
            DataController.DataInstance.bell = currentCapacity; 
            
        }
    }

    // 업그레이드 갱신(수용량, 구매비용)
    public void UpdateSize()
    {
        currentCapacity = currentCapacity + startCapacity * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);

    }


    // 수용량 디스플레이
    public void UpdateDisplay()
    {
        SizeDisplayer.text = sizeName + "\n레벨: " + level + "\n비용: " + currentCost;

    }



}
