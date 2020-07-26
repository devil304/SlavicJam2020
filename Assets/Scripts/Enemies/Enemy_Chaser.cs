using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chaser : Enemy_Base
{
    Pathfinding pf;
    Player player;
    bool triggerConsumed = false;
    private new void Start()
    {
        base.Start();

        pf = GetComponent<Pathfinding>();
        player = FindObjectOfType<Player>();
        Player.PlayerTurnEnd += Move;
    }

    void Move()
    {
        CheckIfHit();
        MoveFinished();
        List<Vector2Int> list = pf.FindPath(new Vector2Int((int)transform.position.x, (int)transform.position.y), player.currentPos);
        if(list.Count > 0)
        {
            Vector2 dir = list[0] - new Vector2Int((int)transform.position.x, (int)transform.position.y);
            StartCoroutine(MoveToDirection(dir.normalized, MoveFinished));
        }
        CheckIfHit();
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

    private void OnDestroy()
    {
        Player.PlayerTurnEnd -= Move;
    }
}
