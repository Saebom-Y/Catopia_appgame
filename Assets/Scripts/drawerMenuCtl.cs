using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawerMenuCtl : MonoBehaviour
{
    //  UI 좌표는 Rect
    public RectTransform drawerButton;
    public bool isClicked;
    public GameObject leftArrow, rightArrow;


    [SerializeReference]
    float m_openSpeed = 0.0f;

    [SerializeField]
    float m_multSpeed;

    [SerializeField]
    AnimationCurve drawer_ani;

    void Start()
    {
        isClicked = false;
    }

    Vector3 originPos;

    public void openCloseCtl()
    {
        if (isClicked)
        {
            m_openSpeed = Mathf.Min(1, m_openSpeed + Time.deltaTime * m_multSpeed);
            leftArrow.SetActive(false);
            rightArrow.SetActive(true);
        }
        else if (!isClicked)
        {
            m_openSpeed = Mathf.Max(0, m_openSpeed - Time.deltaTime * m_multSpeed);
            leftArrow.SetActive(true);
            rightArrow.SetActive(false);
        }

            drawerButton.localPosition = Vector3.Lerp(new Vector3(116.5f, -170, 0), new Vector3(-103, -170, 0), drawer_ani.Evaluate(m_openSpeed));
    }

    private void Update()
    {
        openCloseCtl();
    }


    public void OnClickButton()
    {
        if (!isClicked)
        {
            originPos = drawerButton.transform.position;
            isClicked = true;
        }
        else if (isClicked)
        {
            isClicked = false;
        }
        //m_openSpeed = 0;
    }
}
