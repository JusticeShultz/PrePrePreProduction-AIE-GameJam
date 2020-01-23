using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    float size;
    public PrefabManager objects;

    private void Start()
    {
        size = objects.dungeon.GetComponent<Renderer>().bounds.size.x;
    }


    public void Spawn(string name)
    {
        Vector3 newPos = gameObject.transform.position;
        string wallToDisable = "";

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

        GameObject spawnedDungeon = (GameObject)Instantiate(objects.dungeon, newPos, Quaternion.identity);
        spawnedDungeon.transform.Find(wallToDisable).gameObject.SetActive(false);
    }
}
