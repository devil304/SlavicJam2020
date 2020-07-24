using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2Int currentPos;
    MainInput MI;
    Vector2Int moveDir = new Vector2Int(0,0);
    bool moving = false;
    MapMapper MM;
    // Start is called before the first frame update
    void Start()
    {
        MM = FindObjectOfType<MapMapper>();
        MI = new MainInput();
        MI.Enable();
        MI.Movement.updown.performed += perf => {
            if (!moving)
            {
                moving = true;
                StartCoroutine(Move());
            }
        };
        MI.Movement.leftright.performed += perf => {
            if (!moving)
            {
                moving = true;
                StartCoroutine(Move());
            }
        };

        Clock.Beat += () => {
            BeatT = true;
            Debug.Log("Clock");
            i++;
        };

    }
    bool BeatT = false;
    int i = 0, x = 0;
    IEnumerator Move()
    {
        var tmp = MI.Movement;
        do
        {
            moveDir = new Vector2Int(tmp.leftright.ReadValue<float>()>0?(int)Math.Ceiling(tmp.leftright.ReadValue<float>()): (int)Math.Floor(tmp.leftright.ReadValue<float>()),
                tmp.updown.ReadValue<float>() > 0 ? (int)Math.Ceiling(tmp.updown.ReadValue<float>()) : (int)Math.Floor(tmp.updown.ReadValue<float>()));
            Debug.Log("Move : "+moveDir);
            BeatT = false;
            yield return new WaitUntil(() => BeatT);
            if(x==0)
                x = i;
            else
                x++;
            if (x < i - 1)
            {
                Debug.LogWarning("Skip i: "+i+" x: "+x);
                x = i;
            }
            if (!(moveDir.x != 0 && moveDir.y != 0) && MM.map[currentPos.x + moveDir.x, currentPos.y + moveDir.y].TType == TileType.Floor)
            {
                transform.position += (Vector3Int)moveDir;
                currentPos += moveDir;
            }
        } while (moveDir != Vector2Int.zero);
        moving = false;
        x = 0;
    }
}
