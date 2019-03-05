using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Transform currentPoint;
    [SerializeField] Transform[] points;
    [SerializeField] int currentSelect;
    [SerializeField] float jump;
    [SerializeField] float speed;

    private void Start()
    {
        currentPoint = points[currentSelect];
    }

    private void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, speed * Time.deltaTime);
        //platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.transform.position, Mathf.Abs(speed * Time.deltaTime));
        if (platform.transform.position.x <= currentPoint.position.x)
        {
            currentSelect++;
            platform.transform.Rotate((float)0.0, (float)0.0, (float)1.0);
            if (currentSelect == points.Length)
            {
                currentSelect = 0;
            }
            currentPoint = points[currentSelect];

        }
    }

}
