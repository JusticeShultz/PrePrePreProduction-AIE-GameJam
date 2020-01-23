using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPickup : MonoBehaviour
{
    public Artifact artifact;

    public float pickupRange = 3.0f;

    public LayerMask mask;

    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, pickupRange, mask);

        if(hit.Length > 0 && artifact != null)
        {
            //In range to pickup.
            if(Input.GetKeyDown(KeyCode.E))
            {
                PlayerController.reference.artifacts.Add(artifact);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}