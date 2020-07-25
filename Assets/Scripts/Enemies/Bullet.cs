using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction { get; set; }
    MapMapper MM;
    // Start is called before the first frame update
    void Start()
    {
        MM = FindObjectOfType<MapMapper>(); 
        Player.PlayerTurnEnd += Move;
    }

    void Move()
    {
        if(Direction != null)
        {
            transform.position += new Vector3(Direction.x,Direction.y);

            if(MM.map[(int)transform.position.x, (int)transform.position.y].TType == TileType.Wall)
            {
                Player.PlayerTurnEnd -= Move;
                Destroy(gameObject);
            }
        }
    }
}
