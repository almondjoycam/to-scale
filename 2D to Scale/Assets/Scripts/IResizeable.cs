using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResizeable
{
    Transform GetTransform();
    void Resize(float scaleFactor, float resizeTime);
    Vector3 ScaledPosition(Vector3 worldPosition);
}
