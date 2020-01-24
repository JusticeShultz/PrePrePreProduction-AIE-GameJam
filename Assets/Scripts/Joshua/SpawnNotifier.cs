using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNotifier : MonoBehaviour
{

    GameObject parentObject;

    void Start()
    {
        parentObject = gameObject.transform.parent.gameObject;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            parentObject.GetComponent<DungeonSpawner>().Spawn(transform.position);
        }
    }
}
