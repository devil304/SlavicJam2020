using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaypointData
{
    public Vector2Int pos;
    public bool shoot;
    public Vector2Int dir;

    public WaypointData(Vector2Int pos, bool shoot, Vector2Int dir)
    {
        this.pos = pos;
        this.shoot = shoot;
        this.dir = dir;
    }
}
