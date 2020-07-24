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

    private void Start()
    {
        Player.PlayerTurnEnd += Move;
    }

    void Move() 
    {
        if(!isMovementFinished)
        {
            var direction = waypoints[waypointIndex].transform.position - transform.position;
            MoveToDirection(direction.normalized, StepFinished);
        }
    }

    void StepFinished()
    {
        if(waypointIndex < waypoints.Count)
        {
            var dist = Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position);
            if (dist < 1.1)
            {
                waypointIndex++;
                if(waypointIndex == waypoints.Count)
                {
                    isMovementFinished = true;
                }
            }
                
        } 
    }
}
