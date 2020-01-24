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
    float meshSize;


    private void Start()
    {
        meshSize = GetComponent<Attributes>().size;
        rand = Random.Range(0, objects.dungeons.Length);
        dungeonToSpawn = objects.dungeons[rand];
        size = dungeonToSpawn.GetComponent<Attributes>().size + GetComponent<Attributes>().size;
        doorController = GetComponent<DoorController>();
        player = GameObject.FindGameObjectWithTag("Player");
     
        for (int i = 0; i < Random.Range(0, 3); i++)
        {
            spawnEnemy();
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            doorController.DoorOpen();
        }
    }

    private void spawnEnemy()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-meshSize + 3, meshSize - 3), 0, Random.Range(-meshSize + 3, meshSize - 3));
        randomDirection.Normalize();
        randomDirection *= Random.Range(-meshSize + 3, meshSize - 3);

        GameObject instantiatedEnemy = Instantiate(objects.enemy[Random.Range(0,objects.enemy.Length)], randomDirection+gameObject.transform.position, Quaternion.identity);
        instantiatedEnemy.GetComponent<EnemyAI>().patrolPoints.Add(new Vector3(Random.Range(-meshSize + 3, meshSize - 3), 0, Random.Range(-meshSize + 3, meshSize - 3)));
        instantiatedEnemy.GetComponent<EnemyAI>().patrolPoints.Add(new Vector3(Random.Range(-meshSize + 3, meshSize - 3), 0, Random.Range(-meshSize + 3, meshSize - 3)));
        instantiatedEnemy.transform.SetParent(gameObject.transform);
    }

    public void Spawn(Vector3 exitPoint)
    {

        Vector3 direction = exitPoint - gameObject.transform.position;
        direction.Normalize();
        direction *= size;
        Quaternion rotation = Quaternion.LookRotation(direction);
        GameObject spawnedDungeon = (GameObject)Instantiate(dungeonToSpawn, direction + gameObject.transform.position, rotation);
        player.transform.position += direction/size *2;
        Destroy(gameObject);
    }

}
