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

    public Transform[] patrolPoints;

    public NavMeshAgent agent;

    private ai state = ai.Patrol;

    private enum ai {
        Attack,
        Die,
        Patrol,
        Follow
    }

    int i = 0;


    void Update()
    {
        //finite state machine
        switch(state)
        {
            case ai.Attack:
                Attack();
                break;
            case ai.Die:
                Die();
                break;
            case ai.Patrol:
                Patrol();
                break;
            case ai.Follow:
                Follow();
                break;
            default:
                Patrol();
                break;

        }
        

        if (currentHealth < 0)
        {
            state = ai.Die;
        }
    }


    void Attack()
    {

    }

    void Die()
    {
        agent.isStopped = true;
        //play death animation here
        //here
       
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        //wait 2 sec (let animation play) then destroy enemy
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void Patrol()
    {
       
        agent.destination = patrolPoints[i].position;
        if (Vector3.Distance(agent.destination,transform.position) < 2.0f)
        {
            i++;
            if (i == patrolPoints.Length)
            {
                i = 0;
            }
        }
    }


    void Follow()
    {
        agent.destination = PlayerController.instance.transform.position;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            state = ai.Follow;
        }
    }
}
