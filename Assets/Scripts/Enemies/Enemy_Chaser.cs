using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chaser : Enemy_Base
{
    Pathfinding pf;
    public GameObject test;
    private void Start()
    {
        pf = GetComponent<Pathfinding>();
    }

    private void Update()
    {
        Test();
    }

    void Test()
    {
        List<Vector2Int> list = pf.FindPath(new Vector2Int((int)transform.position.x, (int)transform.position.y), new Vector2Int(1, 1));
        foreach (Vector2Int pos in list)
        {
            Instantiate(test, (Vector3Int)pos, Quaternion.identity);
        }
    }
}
