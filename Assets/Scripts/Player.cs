﻿using System;
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
            if (!(moveDir.x != 0 && moveDir.y != 0) && MM.map[currentPos.x + moveDir.x, currentPos.y + moveDir.y].TType == TileType.Floor)
            {
                transform.position += (Vector3Int)moveDir;
                currentPos += moveDir;
                firstBeat = false;
            }
            //Debug.Log("Move : " + moveDir);
            Debug.DrawLine(new Vector3(4,4,0), new Vector3(5, 5, 0), Color.red, 0.1f);
        };

    }
    bool firstBeat = false;
    IEnumerator Move()
    {
        firstBeat = true;
        var tmp = MI.Movement;
        var tmpDir = new Vector2Int(tmp.leftright.ReadValue<float>() > 0 ? (int)Math.Ceiling(tmp.leftright.ReadValue<float>()) : (int)Math.Floor(tmp.leftright.ReadValue<float>()),
                tmp.updown.ReadValue<float>() > 0 ? (int)Math.Ceiling(tmp.updown.ReadValue<float>()) : (int)Math.Floor(tmp.updown.ReadValue<float>())); ;
        moveDir = tmpDir;
        do
        {
            yield return new WaitForFixedUpdate();
            tmpDir= new Vector2Int(tmp.leftright.ReadValue<float>()>0?(int)Math.Ceiling(tmp.leftright.ReadValue<float>()): (int)Math.Floor(tmp.leftright.ReadValue<float>()),
                tmp.updown.ReadValue<float>() > 0 ? (int)Math.Ceiling(tmp.updown.ReadValue<float>()) : (int)Math.Floor(tmp.updown.ReadValue<float>()));
            moveDir = tmpDir != Vector2Int.zero || !firstBeat ? tmpDir :moveDir;
        } while (moveDir != Vector2Int.zero);
        moving = false;
    }
}
