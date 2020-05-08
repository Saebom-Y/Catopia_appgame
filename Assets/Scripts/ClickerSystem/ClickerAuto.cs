using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerAuto : MonoBehaviour
{

    public Text AutoDisplayer;

    public string autoName;

    public int level;


    // 구매 비용
    public int currentCost;
    public int startCurrentCost = 1;


    // 초당 자동획득
    public int bellPerSec;
    public int startBellPerSec = 1;


    // 업그레이드 할 때마다 구매 비용 증가
    public float upgradePow = 1.07f;
    public float costPow = 3.14f;


    //자동획득 활성/비활성화
    public bool isPurchased = false;


     void Start()
    {

        DataController.DataInstance.LoadAutoButton(this);

     
        StartCoroutine("AddAutoBell");

        UpdateDisplay();
    }


   
    // 자동획득 업그레이드 구매
    public void PurchaseAuto()
    {
        if(DataController.DataInstance.bell >= currentCost)
        {
            isPurchased = true;
            DataController.DataInstance.bell -= currentCost;
            level++;

            UpdateAuto();
            UpdateDisplay();

            DataController.DataInstance.SaveAutoButton(this);
        }
    }

   //자동획득 코루틴 (한번 활성화 시 계속 돌아감)
    IEnumerator AddAutoBell()
    {
        while (true)
        {
            if (isPurchased)
            {
                DataController.DataInstance.bell += bellPerSec;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }


    // 업그레이드 갱신(구매비용, 자동획득량)
    public void UpdateAuto()
    {
        bellPerSec = bellPerSec + startBellPerSec * (int)Mathf.Pow(upgradePow, level);  
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level); 


    }
    

    // 자동획득 디스플레이
    public void UpdateDisplay()
    {
        AutoDisplayer.text = autoName + "\n레벨: " + level + "\n비용: " + currentCost;
            
    }
}
