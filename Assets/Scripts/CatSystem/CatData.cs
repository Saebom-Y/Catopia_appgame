using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatClass
{
    낮,
    밤,
    새벽,
    황혼
}

[System.Serializable]
public class CatData {

    public CatClass catClass;

    public string catName;
    public string catDesc;
    public Sprite catImage;

    
    

}