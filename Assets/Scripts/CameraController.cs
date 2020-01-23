using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 0.15f;

    public Transform target;
    public Vector3 offsetFromTarget;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offsetFromTarget, speed);
    }
}
