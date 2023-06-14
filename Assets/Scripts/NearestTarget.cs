using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestTarget : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] float radius;
    Collider2D[] col;
    public static Transform target;

    void FixedUpdate()
    {
        col = Physics2D.OverlapCircleAll(transform.position,radius,layer);

        target = GetNearestTarget();
    }
    Transform GetNearestTarget()
    {
        Transform result = null;
        float diff = Mathf.Infinity;

        foreach(Collider2D collider2D in col)
        {
            float curDiff = Vector2.SqrMagnitude(transform.position - collider2D.transform.position);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = collider2D.transform;
            }
        }
        return result;
    }
}
