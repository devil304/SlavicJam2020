using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public Node[,] nodes;
    int gridSizeX;
    int gridSizeY;

    // New grid without tile cost
    // Cost is set to 1 if walkable and 0 if not
    public Grid(MapMapper map)
    {
        gridSizeX = map.map.GetLength(0);
        gridSizeY = map.map.GetLength(1);
        nodes = new Node[gridSizeX, gridSizeY];

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if(map.map[x, y] != null)
                {
                    nodes[x, y] = new Node(map.map[x, y]);
                }
                else
                {
                    nodes[x, y] = new Node(x,y);
                }
            }
        }
    }

    // return list of neighbours of given node
    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        // Use this for all 8 directions
        //for (int x = -1; x <= 1; x++)
        //{
        //    for (int y = -1; y <= 1; y++)
        //    {
        //        if (x == 0 && y == 0)
        //            continue;

        //        int checkX = node.gridX + x;
        //        int checkY = node.gridY + y;

        //        if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
        //        {
        //            neighbours.Add(nodes[checkX, checkY]);
        //        }
        //    }
        //}


        // check only 4 directions
        int checkX = node.gridX - 1;
        if (checkX >= 0 && checkX < gridSizeX)
        {
            neighbours.Add(nodes[checkX, node.gridY]);
        }
        checkX = node.gridX + 1;
        if (checkX >= 0 && checkX < gridSizeX)
        {
            neighbours.Add(nodes[checkX, node.gridY]);
        }

        int checkY = node.gridY - 1;
        if (checkY >= 0 && checkY < gridSizeY)
        {
            neighbours.Add(nodes[node.gridX, checkY]);
        }
        checkY = node.gridY + 1;
        if (checkY >= 0 && checkY < gridSizeY)
        {
            neighbours.Add(nodes[node.gridX, checkY]);
        }

        return neighbours;
    }
}
