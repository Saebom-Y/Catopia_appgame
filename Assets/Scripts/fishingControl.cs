using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingControl : MonoBehaviour
{
    [SerializeField]
    GameObject catOb;
    public GameObject mainCanvus, fishingCanvus;
    public GameObject mainCamera;
    public GameObject fishingSlider;

    bool m_backBTcheck = false; // 백버튼체크. 뒤로가기 되었는가?
    float m_cPos = 0.0f;
    [SerializeField]
    float m_aniSpeed;
    [SerializeField]
    AnimationCurve m_ac;

    // 시간 변수
    public float m_randTime= 0;

    // 업데이트 함수
    void Update()
    {
        // 마우스 눌렸을 때
        if (Input.GetMouseButtonDown(0))
        {
            catOb = GetClickedObject();
        }

        // 오브젝트 클릭 체크
        if (catOb != null)
        {
            if (catOb.Equals(gameObject)) // 고양이 눌렀을 때 (낚시 캔버스 진입)
            {
                // 뒤로가기 버튼 다시 false로 초기화
                m_backBTcheck = false;

                mainCanvus.SetActive(false);
                fishingCanvus.SetActive(true);
                m_cPos = Mathf.Min(1, m_cPos + Time.deltaTime * m_aniSpeed);
            }
            else
            {
                catOb = null;
            }
        }

        // 백버튼 눌렸을 때
        if(m_backBTcheck)
        {
            // 카메라 위치 되돌아가기
            m_cPos = Mathf.Max(0, m_cPos - Time.deltaTime * m_aniSpeed);
            // mainCamera.transform.position = Vector3.Lerp(new Vector3(0, 5, -10), new Vector3(1.5f, 7, -5), m_ac.Evaluate(m_cPos));//<-

            // 캔버스 다시 열기
            mainCanvus.SetActive(true);
            fishingCanvus.SetActive(false);

            // 캣 오브젝트 클릭 원래대로 돌려놓기
            catOb = null;
        }
        else
        {
            m_backBTcheck = false;
        }
        
        // 항상 돌아가도록
        mainCamera.transform.position = Vector3.Lerp(new Vector3(0, 5, -10), new Vector3(1.5f, 7, -5), m_ac.Evaluate(m_cPos));

        // 시간 변수
        // m_fishTime = Time.time + m_randTime;
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit_click;
        GameObject catOb = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 포인터 근처의 좌표를 만든다.

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit_click))) // 마우스 근처에 오브젝트가 있는지 체크
        {
            // 있으면 오브젝트 저장
            catOb = hit_click.collider.gameObject;
        }
        return catOb;
    }

    //클릭했을 때 1번 실행되는 함수
    public void clicked_bt_back()
    {
        m_backBTcheck = true;
    }

    public void start_fishing() // 낚시 시작 버튼 클릭
    {
        StartCoroutine("fishing_After_delay");
    }

    IEnumerator fishing_After_delay()
    {
        m_randTime = Random.Range(3.0f, 10.0f);
        yield return new WaitForSeconds(m_randTime);
        fishingSlider.SetActive(true);
    }

}