using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResizer
{

    float scaleFactor = 1.0f;

    public ObjectResizer() {
    }

    //sets multiplicative scale factor to resize objects
    public void SetScaleFactor(float newFactor) {
        scaleFactor = newFactor;
        Debug.Log("scale factor is");
        Debug.Log(scaleFactor);
    }

    //resizes game object
    public void ResizeObject(GameObject obj) {
        Debug.Log("resizing");
        obj.transform.localScale = obj.transform.localScale * scaleFactor;
        for(int i = 0; i < obj.transform.childCount; i++) {
            var objChild = obj.transform.GetChild(i);
        
            objChild.transform.localScale = objChild.transform.localScale
                * scaleFactor;
        }
    }
}
