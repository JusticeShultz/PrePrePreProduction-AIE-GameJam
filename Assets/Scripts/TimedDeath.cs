using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float time = 20f;

    void Start()
    {
        Destroy(gameObject, time);
    }
}
