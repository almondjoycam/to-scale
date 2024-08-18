using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] float scaleFactor = 0.0f;
    ObjectResizer objRe = new ObjectResizer();
    // Start is called before the first frame update
    void Start()
    {
        objRe.SetScaleFactor(scaleFactor);
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
