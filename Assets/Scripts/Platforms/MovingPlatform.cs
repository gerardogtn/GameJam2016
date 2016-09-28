﻿using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    Transform platform;
    [SerializeField]
    float platformSpeed;

    [SerializeField]
    Transform[] endPoints;

    int currentPos;
    int dir;

    Vector3 direction;
    Transform destination;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for ( int i = 0; i < endPoints.Length; i++)
        {
            Gizmos.DrawWireCube(endPoints[i].position, platform.localScale);
        }     
    }

    void Start()
    {
        currentPos = 0;
        dir = 1;
        setDestination(endPoints[currentPos]);
    }          

    void FixedUpdate()
    {
//        platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);
//        platform.position = Vector3.Lerp(platform.position, destination.position, platformSpeed * Time.fixedDeltaTime);
        platform.position = Vector3.MoveTowards(platform.position, destination.position, platformSpeed * Time.fixedDeltaTime);
        if (Vector3.Distance(platform.position, destination.position) <= Time.fixedDeltaTime * platformSpeed * 1.5f)
        {                        
            if (currentPos >= endPoints.Length - 1)
            {
                dir = -1;
            }
            else if (currentPos <= 0)
            {
                dir = 1;
            }
            currentPos += dir;
            Debug.Log(currentPos);
            setDestination(endPoints[currentPos]);
        }
    }

    void setDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
}
