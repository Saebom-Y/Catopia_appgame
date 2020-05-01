using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopButton : MonoBehaviour
{
    public void ClickButton()
    {
        SceneManager.LoadScene("shop");
    }
}
