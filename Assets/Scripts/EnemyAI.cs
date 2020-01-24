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

    public List<Vector3> patrolPoints;

    public NavMeshAgent agent;

    public EnemyHitbox hitbox;
    public GameObject deathEffect;

    [SerializeField]
    private ai state = ai.Patrol;

    public Animator anim;
    public AudioClip attackSound;
    public AudioClip damageSound;
    AudioSource enemySounds;


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

        Vector3 playerPosition = PlayerController.instance.transform.position;

        if (Vector3.Distance(playerPosition, transform.position) < 7)
        {
            state = ai.Follow;
        }

        if (Vector3.Distance(playerPosition, transform.position) < 5)
        {
            state = ai.Attack;
        }

        if (currentHealth < 0)
        {
            state = ai.Die;
        }
    }


    void Attack()
    {
        anim.SetBool("attack", true);

        if (hitbox.objectsInRange.Count > 0)
        {
            PlayerController.reference.currentHealth -= attackDamage;
        }
        //attack
        //check for player position
        //go back to follow or patrol
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
        yield return new WaitForSeconds(0.01f);
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Patrol()
    {
        anim.SetBool("attack", false);

        if (patrolPoints.Count != 0)
        {
            if (agent.isOnNavMesh)
            {
                agent.destination = patrolPoints[i];
                if (Vector3.Distance(agent.destination, transform.position) < 2.0f)
                {
                    i++;
                    if (i == patrolPoints.Count)
                    {
                        i = 0;
                    }
                }
            }
        }
    }


    void Follow()
    {
        anim.SetBool("attack", false);
        agent.destination = PlayerController.instance.transform.position;
    }
}
