using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    [SerializeField] GameObject dungeon;
    float size;

    private void Start()
    {
        size = dungeon.GetComponent<Renderer>().bounds.size.x;
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

        print("spawned");
        GameObject spawnedDungeon = Instantiate(dungeon, newPos ,Quaternion.identity) as GameObject;
        spawnedDungeon.transform.Find(wallToDisable).gameObject.SetActive(false);
    }
}
