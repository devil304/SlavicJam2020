using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction { get; set; }
    MapMapper MM;
    Player player;
    bool hitOccured = false;
    void Start()
    {
        MM = FindObjectOfType<MapMapper>();
        player = FindObjectOfType<Player>();
        Player.PlayerTurnEnd += Move;
    }

    private void Update()
    {
        if (player.currentPos == (Vector2)transform.position && !hitOccured)
        {
            hitOccured = true;
            Debug.Log("Player hit.");
            // do something
        }
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

            if(player.currentPos == (Vector2)transform.position && !hitOccured)
            {
                hitOccured = true;
                Debug.Log("Player hit.");
                // do something
            }
        }
    }
}
