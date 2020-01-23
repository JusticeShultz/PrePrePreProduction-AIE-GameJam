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
        parentObject.GetComponent<DungeonSpawner>().Spawn(gameObject.name);
    }
}
