using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    public float epsilonDistance = 0.001f;
    public Vector3 offset = Vector3.zero;
    public Vector3 scale = Vector3.one;
    public LayerMask collisionMask;
    public bool drawDebugOnSelected = true;

    bool isGrounded { get { return Grounded(); } }
    float groundDistance { get { return GroundedDistance(); } }

    bool Grounded()
    {
        return
            Physics.Raycast(new Ray(transform.position + offset + (new Vector3(scale.x, 0, scale.z) * 0.5f), Vector3.down), epsilonDistance, collisionMask) &&
            Physics.Raycast(new Ray(transform.position + offset + (new Vector3(scale.x, 0, -scale.z) * 0.5f), Vector3.down), epsilonDistance, collisionMask) &&
            Physics.Raycast(new Ray(transform.position + offset + (new Vector3(-scale.x, 0, scale.z) * 0.5f), Vector3.down), epsilonDistance, collisionMask) &&
            Physics.Raycast(new Ray(transform.position + offset + (new Vector3(-scale.x, 0, -scale.z) * 0.5f), Vector3.down), epsilonDistance, collisionMask);
    }

    float GroundedDistance()
    {
        if (!isGrounded) return epsilonDistance;

        float sum = 0f;
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(new Ray(transform.position + offset + (new Vector3(scale.x, 0, scale.z) * 0.5f), Vector3.down), out hit, epsilonDistance, collisionMask))
            sum += hit.distance;

        if(Physics.Raycast(new Ray(transform.position + offset + (new Vector3(scale.x, 0, -scale.z) * 0.5f), Vector3.down), out hit, epsilonDistance, collisionMask))
            sum += hit.distance;

        if (Physics.Raycast(new Ray(transform.position + offset + (new Vector3(-scale.x, 0, scale.z) * 0.5f), Vector3.down), out hit, epsilonDistance, collisionMask))
            sum += hit.distance;

        if (Physics.Raycast(new Ray(transform.position + offset + (new Vector3(-scale.x, 0, -scale.z) * 0.5f), Vector3.down), out hit, epsilonDistance, collisionMask))
            sum += hit.distance;

        return sum * 0.5f;
    }

    private void OnDrawGizmosSelected()
    {
        if (!drawDebugOnSelected) return;

        if (isGrounded)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position + offset + (new Vector3(scale.x, 0, scale.z) * 0.5f), transform.position + offset + (new Vector3(scale.x, -groundDistance, scale.z) * 0.5f));
            Gizmos.DrawLine(transform.position + offset + (new Vector3(scale.x, 0, -scale.z) * 0.5f), transform.position + offset + (new Vector3(scale.x, -groundDistance, -scale.z) * 0.5f));
            Gizmos.DrawLine(transform.position + offset + (new Vector3(-scale.x, 0, scale.z) * 0.5f), transform.position + offset + (new Vector3(-scale.x, -groundDistance, scale.z) * 0.5f));
            Gizmos.DrawLine(transform.position + offset + (new Vector3(-scale.x, 0, -scale.z) * 0.5f), transform.position + offset + (new Vector3(-scale.x, -groundDistance, -scale.z) * 0.5f));
        }
        else
        {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position + offset + (new Vector3(scale.x, 0, scale.z) * 0.5f), transform.position + offset + (new Vector3(scale.x, -5, scale.z) * 0.5f));
            Gizmos.DrawLine(transform.position + offset + (new Vector3(scale.x, 0, -scale.z) * 0.5f), transform.position + offset + (new Vector3(scale.x, -5, -scale.z) * 0.5f));
            Gizmos.DrawLine(transform.position + offset + (new Vector3(-scale.x, 0, scale.z) * 0.5f), transform.position + offset + (new Vector3(-scale.x, -5, scale.z) * 0.5f));
            Gizmos.DrawLine(transform.position + offset + (new Vector3(-scale.x, 0, -scale.z) * 0.5f), transform.position + offset + (new Vector3(-scale.x, -5, -scale.z) * 0.5f));
        }
    }
}