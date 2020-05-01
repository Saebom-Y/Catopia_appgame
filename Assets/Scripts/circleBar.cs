using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleBar : MonoBehaviour
{
    [SerializeField]
    Image m_icon; //눈금 이미지
    [SerializeField]
    float m_circleRange; //궤도 크기
    [SerializeField]
    float m_minAngle; //궤도 시작 각도
    [SerializeField]
    float m_circleAngle; //궤도 각도 크기

    public float m_gage; //현재 눈금 게이지

    [SerializeField]
    float m_maxGage; //눈금 최대 게이지

    [SerializeField]
    float m_clearMin; //범위 최소 게이지
    [SerializeField]
    float m_clearMax; //범위 최대 게이지

    [SerializeField]
    float m_gageSpd;

    //360도각도 단위에서 벡터로 바꾸기 위해 곱해야 하는 상수값
    float m_toVector = Mathf.Asin(1) * 4.0f / 360.0f;

    // Update is called once per frame
    void Update()
    {
        

        //게이지 범위를 0~1로 만들어준다
        float perGage = m_gage / m_maxGage;

        //360도각도 범위를 벡터로 변환------------------------------------------
        float vec= m_toVector * (m_minAngle + m_circleAngle * perGage);
        m_icon.rectTransform.localPosition = new Vector3(Mathf.Cos(vec), Mathf.Sin(vec), 0) * m_circleRange;
        //---------------------------------------------------------------------

        m_gage = m_gage + m_gageSpd /* 속도값 */ * Time.deltaTime;

        //m_gage의 값을 0~m_maxGage 범위 밖에 나가지 않게 해줌
        m_gage = Mathf.Clamp(m_gage, 0, m_maxGage);

        if (m_gage == 100)
            m_gageSpd = -Mathf.Abs(m_gageSpd);
        else if (m_gage == 0)
            m_gageSpd = Mathf.Abs(m_gageSpd); // m_gage가 0일 때, speed 절댓값

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_gage >= m_clearMin && m_gage <= m_clearMax)
            {
                Debug.Log("성공");
            }
            else
            {
                Debug.Log("범위 바깥입니다");
            }
        }
    }
}