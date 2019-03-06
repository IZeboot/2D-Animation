using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
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
        currentPoint.position = new Vector3(currentPoint.position.x, jump);
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, speed * Time.deltaTime);
        int positionX = Mathf.FloorToInt(platform.transform.position.x - currentPoint.position.x);
        if (positionX == -1 || positionX == 1)
        {

            platform.transform.Rotate((float)0.0, (float)180.0, (float)0.0);
            currentSelect++;
            if (currentSelect == points.Length)
            {
                currentSelect = 0;
            }
            currentPoint = points[currentSelect];

        }
    }

}