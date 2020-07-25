using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walker : Enemy_Base
{
    [SerializeField] private GameObject WaypointsContainer;
    [SerializeField] private List<GameObject> waypoints; //Array zajmuje mniej i jest szybszy, a nie modyfikujesz w kodzie listy
    private int waypointIndex = 0; //w C# domyślnie zmienne są private lub internal, więc można nie pisać ;)
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
            var dist = Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position); //Vector2.Distance byłby lepszy bo nie bierzemy pod uwagę osi z (Vector2 i Vector3 mają bezpośrednie konwersje) 
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
