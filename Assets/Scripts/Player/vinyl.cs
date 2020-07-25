using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinyl : MonoBehaviour
{
    [HideInInspector]public Vector2Int dir;
    [HideInInspector]public float time;
    [HideInInspector]public MapMapper MM;
    public void MoveVinyl()
    {
        if(!trig)
            StartCoroutine(MoveToPosition());
    }
    bool trig = false;
    public IEnumerator MoveToPosition()
    {
        trig = true;
        var pos = Vector2Int.RoundToInt(transform.position) + dir;
        yield return new WaitForSecondsRealtime(time / 2f);
        transform.position += (Vector3)((Vector2)dir / 2f);
        yield return new WaitForSecondsRealtime(time / 2f);
        if (MM.map[pos.x, pos.y].TType != TileType.Wall)
        {
            transform.position += (Vector3)((Vector2)dir / 2f);
        }
        else
        {
            Player.PlayerTurnEnd -= MoveVinyl;
            MM.pros.Remove(this);
            Destroy(gameObject);
        }
        trig = false;
    }


}
