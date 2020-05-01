using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stoneScript : MonoBehaviour
{
    // 구름돌 버튼 변수
    [SerializeField]
    GameObject s_Dawn;
    [SerializeField]
    GameObject s_Daytime;
    [SerializeField]
    GameObject s_Twilight;
    [SerializeField]
    GameObject s_Night;

    // 구름돌 갯수 표시 (텍스트) 변수 선언
    [SerializeField]
    Text t_Dawn;
    [SerializeField]
    Text t_Daytime;
    [SerializeField]
    Text t_Twilight;
    [SerializeField]
    Text t_Night;
    int m_sDawn = 999;
    int m_sDaytime = 999;
    int m_sTwilight = 999;
    int m_sNight = 999;

    public void used_Dawn()
    {
        m_sDawn -= 1;
        // 상태변경 = 새벽
    }

}
