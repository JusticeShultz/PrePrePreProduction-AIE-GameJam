using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public static int gems = 0;
    
    public int value;
    public float attractTime = 0.4f;
    public float explodeVelocity = 500f;

    public Rigidbody rb;

    float atc = 0f;

    private void OnEnable()
    {
        rb.AddForce(Random.insideUnitSphere * Time.deltaTime * 100 * explodeVelocity);
    }

    void FixedUpdate()
    {
        atc += Time.deltaTime;

        if (atc >= attractTime)
        {
            rb.isKinematic = true;

            transform.position = Vector3.Lerp(transform.position, PlayerController.instance.transform.position, 0.07f);

            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= 1.2f)
            {
                gems += value;

                Destroy(gameObject);
            }
        }
    }
}