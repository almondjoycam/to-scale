using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float damping;

    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerControls>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        destination = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );
        transform.position = Vector3.Lerp(
            transform.position,
            destination,
            damping
        );
    }
}
