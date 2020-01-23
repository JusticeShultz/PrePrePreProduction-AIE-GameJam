using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController reference;
    public static GameObject instance;

    public float speed = 0.15f;

    public Transform target;
    public Vector3 offsetFromTarget;

    private void Start()
    {
        reference = this;
        instance = gameObject;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offsetFromTarget, speed);
    }
}
