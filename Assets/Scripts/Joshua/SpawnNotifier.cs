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


    void OnTriggerEnter()
    {
        print("called");
        parentObject.GetComponent<DungeonSpawner>().Spawn(gameObject.name);
        gameObject.SetActive(false);
    }
}
