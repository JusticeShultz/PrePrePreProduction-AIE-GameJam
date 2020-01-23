using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    float size;
    public PrefabManager objects;

    public void Spawn(string name)
    {
        Vector3 newPos = gameObject.transform.position;
        string wallToDisable = "";

        GameObject dungeonToSpawn = objects.dungeons[Random.Range(0, objects.dungeons.Length - 1)];

        size = dungeonToSpawn.GetComponent<Renderer>().bounds.size.x;

        switch (name)
        {
            case "WallRight":
                newPos.x += size;
                wallToDisable = "WallLeft";
                break;
            case "WallLeft":
                newPos.x -= size;
                wallToDisable = "WallRight";
                break;
            case "WallUp":
                newPos.z += size;
                wallToDisable = "WallDown";
                break;
            case "WallDown":
                newPos.z -= size;
                wallToDisable = "WallUp";
                break;
            default:
                break;
        }

        GameObject spawnedDungeon = (GameObject)Instantiate(dungeonToSpawn, newPos, Quaternion.identity);
        spawnedDungeon.transform.Find(wallToDisable).gameObject.SetActive(false);
        StartCoroutine(EnableWall(spawnedDungeon.transform.Find(wallToDisable).gameObject));
    }

    IEnumerator EnableWall(GameObject wall)
    {
        yield return new WaitForSeconds(2);
        wall.SetActive(true);
        Destroy(gameObject);
    }
}
