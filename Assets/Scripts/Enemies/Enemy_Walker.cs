using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walker : Enemy_Base
{
    
    int waypointIndex = 0;
    bool isMovementFinished = false;
#if UNITY_EDITOR
    public Transform WaypointsContainerEditor;
    public WaypointEdit[] waypointsEditor;
    public GameObject[] prefs;
#endif
    public WaypointData[] waypoints;

    private void Start()
    {
        Player.PlayerTurnEnd += Move;
    }

    void Move() 
    {
        if(!isMovementFinished)
        {
            var direction = (Vector3Int)waypoints[waypointIndex].pos - transform.position;
            MoveToDirection(direction.normalized, StepFinished);
        }
    }

    void StepFinished()
    {
        if(waypointIndex < waypoints.Length)
        {
            var dist = Vector3.Distance(transform.position, (Vector3Int)waypoints[waypointIndex].pos); //Vector2.Distance byłby lepszy bo nie bierzemy pod uwagę osi z (Vector2 i Vector3 mają bezpośrednie konwersje) 
            if (dist < 1.1)
            {
                waypointIndex++;
                if(waypointIndex == waypoints.Length)
                {
                    isMovementFinished = true;
                }
            }
                
        } 
    }
}
