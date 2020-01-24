using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public float damage = 1f;

    public static bool swinging = false;

    void Start()
    {
        swinging = false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if(swinging && collision.transform.tag == "Enemy")
        {
            EnemyAI ai = collision.transform.GetComponent<EnemyAI>();

            float dmg = 0;

            for(int i = 0; i < PlayerController.reference.artifacts.Count; i++)
            {
                dmg += PlayerController.reference.artifacts[i].damage;
            }

            //Deal damage
            ai.currentHealth -= Mathf.Clamp((damage + PlayerController.reference.damage + dmg) - ai.armor, 0, float.PositiveInfinity);
        }
    }
}