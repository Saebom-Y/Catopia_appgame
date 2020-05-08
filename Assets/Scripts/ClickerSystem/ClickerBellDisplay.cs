using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerBellDisplay : MonoBehaviour
{
    public Text bellDisplay;





    void Update()
    {
        bellDisplay.text = "Bell: " + DataController.DataInstance.bell;
       
    }
}
