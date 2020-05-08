using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    //싱글톤
    private static DataController dataInstance;

    public static DataController DataInstance
    {
       get{
            if (dataInstance == null)
            {
                dataInstance = FindObjectOfType<DataController>();

                if (dataInstance == null)
                {
                    GameObject container = new GameObject("DataController");

                    container.AddComponent<DataController>();
                }
            }
            
   
            return dataInstance;
            
        }
    }

    public long bell
    {
        get
        {
            if (!PlayerPrefs.HasKey("Bell"))
            {
                return 0;
            }
            
            string tmpBell = PlayerPrefs.GetString("Bell");
            return long.Parse(tmpBell);
        }
        set
        {
            PlayerPrefs.SetString("Bell", value.ToString());
        }
    }

    public int bellPerClick
    {
        get
        {
            return PlayerPrefs.GetInt("BellPerClick", 1);
        }

        set
        {
            PlayerPrefs.SetInt("BellPerClick", value);
        }
    }


    void Awake()
    {
        //PlayerPrefs.DeleteAll();
     
     
    }



    //클릭 당 획득 로드
    public void LoadUpgradeButton(ClickerUpgrade clickerUpgrade)
    {
        string key = clickerUpgrade.upgradeName;

        clickerUpgrade.level = PlayerPrefs.GetInt(key + "_level", 1);
        clickerUpgrade.bellByUpgrade = PlayerPrefs.GetInt(key + "_bellByUpgrade", clickerUpgrade.startBellByUpgrade);
        clickerUpgrade.currentCost = PlayerPrefs.GetInt(key + "_cost", clickerUpgrade.startCurrentCost);
    }


    //클릭 당 획득 세이브
    public void SaveUpgradeButton(ClickerUpgrade clickerUpgrade)
    {
        string key = clickerUpgrade.upgradeName;

        PlayerPrefs.SetInt(key + "_level", clickerUpgrade.level);
        PlayerPrefs.SetInt(key + "_bellByUpgrade", clickerUpgrade.startBellByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", clickerUpgrade.startCurrentCost);
    }


    //클리커 자동획득 로드
    public void LoadAutoButton(ClickerAuto clickerAuto)
    {
        string key = clickerAuto.autoName;

        clickerAuto.level = PlayerPrefs.GetInt(key + "_level");
        clickerAuto.currentCost = PlayerPrefs.GetInt(key + "_cost", clickerAuto.startCurrentCost);
        clickerAuto.bellPerSec = PlayerPrefs.GetInt(key + "_bellPerSec");

        if(PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            clickerAuto.isPurchased = true;
        }
        else
        {
            clickerAuto.isPurchased = false;
        }

    }

    
    //클리커 자동획득 세이브
    public void SaveAutoButton(ClickerAuto clickerAuto)
    {
        string key = clickerAuto.autoName;

        PlayerPrefs.SetInt(key + "_level", clickerAuto.level);
        PlayerPrefs.SetInt(key + "_cost", clickerAuto.currentCost);
        PlayerPrefs.SetInt(key + "_bellPerSec", clickerAuto.bellPerSec);

        if (clickerAuto.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }



    //클리커 획득량 로드
    public void LoadSizeButton(ClickerSize clickerSize)
    {
        string key = clickerSize.sizeName;

        clickerSize.level = PlayerPrefs.GetInt(key + "_level", 1);
        clickerSize.currentCapacity = PlayerPrefs.GetInt(key + "_capacity", clickerSize.startCapacity);
        clickerSize.currentCost = PlayerPrefs.GetInt(key + "_cost", clickerSize.startCurrentCost);


    }

    

    //클리커 획득량 세이브
    public void SaveSizeButton(ClickerSize clickerSize)
    {
        string key = clickerSize.sizeName;

        PlayerPrefs.SetInt(key + "_level", clickerSize.level);
        PlayerPrefs.SetInt(key + "_capacity", clickerSize.currentCapacity);
        PlayerPrefs.SetInt(key + "_cost", clickerSize.startCurrentCost);

    }
 




    // 아이템 구매 로드
    public void LoadPurchaseButton(ShopPurchase purchasebutton)
    {
        string key = purchasebutton.purchaseName;


        purchasebutton.num_1 = PlayerPrefs.GetInt(key + "_num_1", 0);
        purchasebutton.num_2 = PlayerPrefs.GetInt(key + "_num_2", 0);
        purchasebutton.num_3 = PlayerPrefs.GetInt(key + "_num_3", 0);




    }

    //아이템 구매 세이브
    public void SavePurchaseButton(ShopPurchase purchasebutton)
    {
        string key = purchasebutton.purchaseName;

        PlayerPrefs.SetInt(key + "_num_1", purchasebutton.num_1);
        PlayerPrefs.SetInt(key + "_num_2", purchasebutton.num_2);
        PlayerPrefs.SetInt(key + "_num_3", purchasebutton.num_3);

    }

}
