using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chaser : Enemy_Base
{
    Pathfinding pf;
    Player player;
    bool triggerConsumed = false;
    private void Start()
    {
        pf = GetComponent<Pathfinding>();
        player = FindObjectOfType<Player>();
        Player.PlayerTurnEnd += Move;
    }

    void Move()
    {
        List<Vector2Int> list = pf.FindPath(new Vector2Int((int)transform.position.x, (int)transform.position.y), player.currentPos);
        if(list.Count > 0)
        {
            Vector2 dir = list[0] - new Vector2Int((int)transform.position.x, (int)transform.position.y);
            MoveToDirection(dir.normalized);
            MoveFinished();
        }
    }

    private void Update()
    {
        MoveFinished();
    }

    void MoveFinished()
    {
        if(!triggerConsumed)
        {
            if (player.currentPos == (Vector2)transform.position)
            {
                triggerConsumed = true;
                Debug.Log("Player hit.");
            }
        } 
    }
}
