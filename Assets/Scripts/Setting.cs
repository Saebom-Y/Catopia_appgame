using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider slider_bgm;
    public AudioSource bgm;

    public Slider slider_se;
    public AudioSource se;

    float bgm_Vol = 1.0f;
    float se_Vol = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // bgm_Vol = 
    }

    // Update is called once per frame
    void Update()
    {
        BGMslider();
        SEslider();
    }

    void BGMslider()
    {
        bgm.volume = slider_bgm.value;

        bgm_Vol = slider_bgm.value;
    }

    void SEslider()
    {
        se.volume = slider_se.value;

        se_Vol = slider_se.value;
    }
}
