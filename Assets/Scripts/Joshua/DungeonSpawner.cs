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

    private void Start()
    {
        dungeonToSpawn = objects.dungeons[Random.Range(0, objects.dungeons.Length)];
        size = dungeonToSpawn.GetComponent<Attributes>().size + GetComponent<Attributes>().size;
        doorController = GetComponent<DoorController>();
        StartCoroutine(DoorDisable());
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void Spawn(string name)
    {
        print("called");
        Vector3 newPos = gameObject.transform.position;

        switch (name)
        {
            case "WallRight":
                newPos.x += size;
                break;
            case "WallLeft":
                newPos.x -= size;
                break;
            case "WallUp":
                newPos.z += size;
                break;
            case "WallDown":
                newPos.z -= size;
                break;
            default:
                break;
        }

        GameObject spawnedDungeon = (GameObject)Instantiate(dungeonToSpawn, newPos, Quaternion.identity);
        player.transform.position = newPos + Vector3.up;
        Destroy(gameObject, 1f);
    }


    IEnumerator DoorEnable()
    {
        yield return new WaitForSeconds(1);
        doorController.DoorClosed();
        StartCoroutine(DoorDisable());
    }

    IEnumerator DoorDisable()
    {
        yield return new WaitForSeconds(1);
        doorController.DoorOpen();
        StartCoroutine(DoorEnable());
    }


}
