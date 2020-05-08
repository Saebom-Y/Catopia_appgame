using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTabPanel : MonoBehaviour
{
    public List<CatTabButton> catTabButtons;
    public List<GameObject> contentsPanels;
    int selected = 0;

    private void Start()
    {
        ClickTab(selected);
    }

    public void ClickTab(int id) // BookUI-Cat에 id값 있음 'Elenment~"가 id값
    {
        // i값이 id값과 같을 때 원하는 탭 호출
        for (int i = 0; i < contentsPanels.Count; i++)
        {
            if (i == id)
            {
                contentsPanels[i].SetActive(true);

            }
            // 그 외 나머지는 비활성화
            else
            {
                contentsPanels[i].SetActive(false);
            }
        }

    }
   


}
