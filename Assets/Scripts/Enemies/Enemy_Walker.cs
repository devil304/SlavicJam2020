using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walker : Enemy_Base
{
    [SerializeField] private GameObject WaypointsContainer;
    [SerializeField] private List<GameObject> waypoints;
    private int waypointIndex = 0;
    private bool isMovementFinished = false;
    private void Awake()
    {
        WaypointsContainer.SetActive(false);
    }

    float time = 2f;
    private void Update()
    {
        if(!isMovementFinished)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 2f;

                var direction = waypoints[waypointIndex].transform.position - transform.position;

                MoveToDirection(direction.normalized, StepFinished);
            }
        }
    }

    void StepFinished()
    {
        if(waypointIndex < waypoints.Count)
        {
            if (transform.position == waypoints[waypointIndex].transform.position)
                waypointIndex++;
        } 
        else if(waypointIndex == waypoints.Count)
        {
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                isMovementFinished = true;
            }
        }
    }
}
