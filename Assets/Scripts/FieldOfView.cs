using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewAngle;
    [Range(0,360)]
    public float viewRadius;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {

        while (true)
        {

            yield return new WaitForSeconds(delay);
            FindVisibleTargets();

        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();

        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            Debug.Log((Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
            if((Vector2.Angle(transform.forward, dirToTarget) < viewAngle / 2 && (Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) < 0 )) || 
            (Vector2.Angle(transform.forward, dirToTarget) > (viewAngle + 180) / 2 && Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) > 0))
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);
                if(Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrres, bool isGlobalAngle)
    {
        if (!isGlobalAngle)
        {
            angleInDegrres += transform.position.y;
        }

        return new Vector3(Mathf.Cos(angleInDegrres * Mathf.Deg2Rad), Mathf.Sin(angleInDegrres * Mathf.Deg2Rad) );
    }

}
