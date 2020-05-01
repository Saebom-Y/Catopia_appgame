using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerBtn : MonoBehaviour
{
    public int bell = 0;

    public int bellPerClick = 1; // 한번 클릭할 때마다 얻는 벨 수

    public Text bellDisplay;

    public GameObject pur;

    




    public void Onclick()
    {
        bell = bell + bellPerClick;
    }

    private void Update()
    {
        bellDisplay.text = "Bell : " + bell;
    }

    public void UpgradeBtn()
    {

        bellPerClick += 1;
    }


    //임시 코드(삭제 예정)
    //방울이 있으면 구매가능, 방울 없을 시 구매불가 텍스트 띄우기.
    public void BuyItem()
    {
        if(bell <= 0)
        {
            pur.GetComponent<Text>().text = "구매불가";
            pur.SetActive(true);
            
        }
        else
        {
            bell -= 1;
            pur.SetActive(false);
        }
       
    }
    

 
}
