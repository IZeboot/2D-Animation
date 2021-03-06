﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowPlayer : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform playerTransform;
    [SerializeField] int distanceCurrent;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform.transform.position = new Vector3(playerTransform.position.x, cameraTransform.position.y, cameraTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTransform.position.x > cameraTransform.position.x)
        {
            int distance = Mathf.FloorToInt(playerTransform.position.x - cameraTransform.position.x);

            if(distance > distanceCurrent)
            {
                float positionX = playerTransform.position.x - distance;
                cameraTransform.transform.position = new Vector3(positionX, cameraTransform.position.y, cameraTransform.position.z);
            }
        }
        else{
            int distance = Mathf.FloorToInt(cameraTransform.position.x - playerTransform.position.x);
            if (distance > distanceCurrent)
            {
                float positionX = playerTransform.position.x + distance;
                cameraTransform.transform.position = new Vector3(positionX, cameraTransform.position.y, cameraTransform.position.z);
            }
        }
        if (playerTransform.position.y > cameraTransform.position.y)
        {
            int distance = Mathf.FloorToInt(playerTransform.position.y - cameraTransform.position.y);

            if (distance > distanceCurrent/2)
            {
                float positionY = playerTransform.position.y - distance;
                cameraTransform.transform.position = new Vector3(cameraTransform.position.x, positionY, cameraTransform.position.z);
            }
        }
        else
        {
            int distance = Mathf.FloorToInt(cameraTransform.position.y - playerTransform.position.y);
            if (distance > distanceCurrent/2)
            {
                float positionY = playerTransform.position.y + distance;
                cameraTransform.transform.position = new Vector3(cameraTransform.position.x, positionY, cameraTransform.position.z);
            }
        }
    }
}
