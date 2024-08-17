using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjectResizer
{

    float scaleFactor = 1.0;

    public void SetScaleFactor(float newFactor) {
        scaleFactor = newFactor;
    }

    void ResizeObject(GameObject obj) {
        foreach(var objChild in obj.tran) {
            
        
            objChild.transform.scale.x =  objChild.transform.scale.x * scaleFactor
            objChild.transform.scale.y = objChild.transform.scale.y * scaleFactor
        }
    }
}
