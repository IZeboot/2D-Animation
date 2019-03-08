using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewAngle;
    [Range(0,360)]
    public float viewRadius;

    public Vector3 DirFromAngle(float angleInDegrres, bool isGlobalAngle)
    {
        if (!isGlobalAngle)
        {
            angleInDegrres += transform.position.y;
        }

        return new Vector3(Mathf.Cos(angleInDegrres * Mathf.Deg2Rad), Mathf.Sin(angleInDegrres * Mathf.Deg2Rad) );
    }

}
