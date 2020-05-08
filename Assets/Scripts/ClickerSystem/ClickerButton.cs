using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerButton : MonoBehaviour
{

  

    public void Click()
    {

        DataController.DataInstance.bell += DataController.DataInstance.bellPerClick;
    }
}
