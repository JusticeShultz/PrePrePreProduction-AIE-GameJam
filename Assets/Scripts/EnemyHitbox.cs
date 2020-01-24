using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public List<GameObject> objectsInRange = new List<GameObject>();

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "Player")
            objectsInRange.Add(collision.gameObject);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            for(int i = 0; i < objectsInRange.Count; i++)
            {
                if(objectsInRange[i] == collision.gameObject)
                {
                    objectsInRange.Remove(objectsInRange[i]);
                    break;
                }
            }
        }
    }
}