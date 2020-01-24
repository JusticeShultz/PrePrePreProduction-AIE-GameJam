using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    float size;
    public PrefabManager objects;
    GameObject dungeonToSpawn;
    DoorController doorController;
    private GameObject player;
    int rand = 0;

    private void Start()
    {
        rand = Random.Range(0, objects.dungeons.Length);
        dungeonToSpawn = objects.dungeons[rand];
        size = dungeonToSpawn.GetComponent<Attributes>().size + GetComponent<Attributes>().size;
        doorController = GetComponent<DoorController>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(open());
    }


    public void Spawn(Vector3 exitPoint)
    {

        Vector3 direction = exitPoint - gameObject.transform.position;
        direction.Normalize();
        direction *= size;
        Quaternion rotation = Quaternion.LookRotation(direction);
        GameObject spawnedDungeon = (GameObject)Instantiate(dungeonToSpawn, direction + gameObject.transform.position, rotation);
        player.transform.position += direction/size *2;
        Destroy(gameObject, 1f);
    }

    IEnumerator open()
    {
        yield return new WaitForSeconds(2.0f);
        doorController.DoorOpen();
        StartCoroutine(close());
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(2.0f);
        doorController.DoorClosed();
        StartCoroutine(open());
    }

}
