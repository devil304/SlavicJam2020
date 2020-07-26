using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_JukeBoxFinder : Enemy_Base
{
    Pathfinding pathfinding;
    Vector2Int? target;
    List<Vector2Int> path;
    
    private new void Start()
    {
        base.Start();

        pathfinding = GetComponent<Pathfinding>();
        target = FindJukeBox();
        if(target != null)
        {
            path = pathfinding.FindPath(new Vector2Int((int)transform.position.x, (int)transform.position.y), (Vector2Int)target);
            if(path.Count > 0)
            {
                Player.PlayerTurnEnd += Move;
            }
        }
    }

    void Move()
    {
        CheckIfHit();
        if (path.Count > 0)
        {
            Vector2 dir = path[0] - new Vector2Int((int)transform.position.x, (int)transform.position.y);
            StartCoroutine(MoveToDirection(dir.normalized, MoveFinished));

            path.RemoveAt(0);
        }
        else
        {
            Player.PlayerTurnEnd -= Move;
        }
    }

    void MoveFinished()
    {
        if (MM.map[(int)transform.position.x, (int)transform.position.y].hasJukeBox)
        {
            MM.die();
        }
        CheckIfHit();
    }

    Vector2Int? FindJukeBox()
    {
        for(int i = 0; i < MM.map.GetLength(0); i++)
        {
            for (int j = 0; j < MM.map.GetLength(1); j++)
            {
                if(MM.map[i, j] != null)
                {
                    if (MM.map[i, j].hasJukeBox)
                        return new Vector2Int((int)MM.map[i, j].transform.position.x, (int)MM.map[i, j].transform.position.y);
                }
            }
        }

        return null;
    }

    private void OnDestroy()
    {
        Player.PlayerTurnEnd -= Move;
    }
}
