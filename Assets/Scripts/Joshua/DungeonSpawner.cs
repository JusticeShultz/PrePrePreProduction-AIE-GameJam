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
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(open());

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
        Vector3 direction = newPos - gameObject.transform.position;
        direction.Normalize();
        player.transform.position += direction*2;
        Destroy(gameObject, 1f);
    }

    IEnumerator open()
    {
        yield return new WaitForSeconds(1.0f);
        doorController.DoorOpen();
        StartCoroutine(close());
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(1.0f);
        doorController.DoorClosed();
        StartCoroutine(open());
    }

}
