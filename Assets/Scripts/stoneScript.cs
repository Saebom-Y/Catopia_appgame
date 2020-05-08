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

    // 상태 변환 변수
    bool b_dawnNow = false;
    bool b_daytimeNow = true;
    bool b_twilightNow = false;
    bool b_nightNow = false;

    private void Update()
    {
        t_Dawn.text = m_sDawn.ToString();
        t_Daytime.text = m_sDaytime.ToString();
        t_Twilight.text = m_sTwilight.ToString();
        t_Night.text = m_sNight.ToString();

        if (b_dawnNow == true)
        {

        }

    }

    public void used_Dawn()
    {
        // 새벽 구름돌 사용
        m_sDawn -= 1;
    }

    public void used_Daytime()
    {
        // 낮 구름돌 사용
        m_sDaytime -= 1;
    }

    public void used_Twilight()
    {
        // 황혼 구름돌 사용
        m_sTwilight -= 1;
    }

    public void used_Night()
    {
        // 밤 구름돌 사용
        m_sNight -= 1;
    }
}
