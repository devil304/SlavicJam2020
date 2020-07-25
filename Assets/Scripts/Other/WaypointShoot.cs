using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointShoot : MonoBehaviour
{
    [SerializeField] private GameObject Direction;

    public Vector2 ShootDirection { get ; set; }

    private void Start()
    {
        ShootDirection = new Vector2(Direction.transform.up.x, Direction.transform.up.y);
    }
}
