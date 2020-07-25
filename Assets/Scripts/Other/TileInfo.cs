using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileInfo : MonoBehaviour
{
    public bool HasTable = false, hasJukeBox = false;
    public TileType TType;
}

public enum TileType { Wall, Floor };
