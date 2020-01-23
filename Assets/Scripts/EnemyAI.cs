using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float maxHealth = 15f;
    public float currentHealth = 15f;
    public float armor;
    public float healthRegen;
    public float attackDamage;
    public float attackSpeed;
    public float attackRange;
    public float blockChance;

    public NavMeshAgent agent;

    void Update()
    {
        agent.destination = PlayerController.instance.transform.position;
    }
}
