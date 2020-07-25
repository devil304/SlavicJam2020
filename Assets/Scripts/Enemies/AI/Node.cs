using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable; // is node walkable?
    public int gridX;     // node index X
    public int gridY;     // node index Y  
    public float cost;    // node cost

    public int gCost;     // distance from starting node
    public int hCost;     // distance from end node
    public Node parent;

    public Node(TileInfo info)
    {
        gridX = (int)info.transform.position.x;
        gridY = (int)info.transform.position.y;
        if(info.TType == TileType.Floor)
        {
            cost = 1f;
            walkable = true;
        }
        else
        {
            cost = 0f;
            walkable = false;
        }
    }

    public Node(int x, int y)
    {
        gridX = x;
        gridY = y;
        cost = 0f;
        walkable = false;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
