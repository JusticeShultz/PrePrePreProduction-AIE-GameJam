using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject instance;
    public static PlayerController reference;

    public float maxHealth
    {
        get
        {
            float healthSum = 0;

            for (int i = 0; i < artifacts.Count; i++)
                healthSum += artifacts[i].health;

            healthSum += baseHealth;

            float percent = 0f;

            for (int i = 0; i < artifacts.Count; i++)
                percent += artifacts[i].health_percentage;

            healthSum += healthSum * percent;

            return baseHealth + healthSum;
        }
    }

    public float baseHealth = 5f;
    public float currentHealth = 5f;
    public float movementSpeed = 20f;
    public float rollSpeed = 500;
    public float rollCooldown = 1.2f;
    public float rollCooldownDelay = 0.5f;
    public float damage = 1;
    public float attackSpeed = 1.1f;

    public List<Artifact> artifacts = new List<Artifact>();

    public Rigidbody rb;

    public Animator animator;

    float rollcharge = 0f;
    float rollchargeCD = 0f;
    float attackCD = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = gameObject;
        reference = this;
    }

    //private void Update()
    //{
        
    //}

    void FixedUpdate()
    {
        attackCD -= Time.deltaTime;

        rollcharge -= Time.deltaTime;

        if (rollcharge <= 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                Vector3 direction = target - transform.position;
                float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rotation, 0), 0.25f);
            }

            rb.AddForce(((new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime) * movementSpeed) * 100);

            rollchargeCD -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && rollcharge <= 0 && rollchargeCD <= 0)
        {
            rb.velocity = Vector3.zero;
            rollcharge = rollCooldown;
            rollchargeCD = rollCooldownDelay;

            rb.AddForce((transform.forward * Time.deltaTime * rollSpeed) * 100, ForceMode.Acceleration);
        }

        if (rollcharge > 0)
        {
            rb.drag = 3;
        }
        else
        {
            rb.drag = 25;

            if (Input.GetMouseButtonDown(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerSlash"))
            {
                attackCD = attackSpeed;
                animator.SetTrigger("Attack");
            }
        }

        PlayerSword.swinging = animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerSlash");
    }
}