using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    ObjectResizer objRe = new ObjectResizer();
    // Start is called before the first frame update
    void Start()
    {
        objRe.SetScaleFactor(1.0005f);
    }

    // Update is called once per frame
    void Update()
    {
        objRe.ResizeObject(gameObject);             
    }

    private void OnMouseUp() {
        Debug.Log("event done");
   
    }
}
