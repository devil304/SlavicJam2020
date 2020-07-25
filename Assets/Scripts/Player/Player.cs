﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PT();
public class Player : MonoBehaviour
{
    public static event PT PlayerTurnEnd;
    public Vector2Int currentPos;
    MainInput MI;
    Vector2Int moveDir = new Vector2Int(0,0);
    bool moving = false;
    MapMapper MM;
    Animator myAnim;
    SpriteRenderer mySR;
    float time;
    // Start is called before the first frame update
    void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
        time = FindObjectOfType<Clock>().beatTime;
        myAnim = GetComponent<Animator>();
        myAnim.SetFloat("Speed",(1f/(time/2f)));
        MM = FindObjectOfType<MapMapper>();
        MI = new MainInput();
        MI.Enable();
        MI.Movement.Movment.performed += perf => {
            if (!moving)
            {
                moving = true;
                StartCoroutine(Move());
            }
        };
        MI.Movement.Attack.performed += perf =>
        {

        };

        Clock.Beat += () => {
            if (!(moveDir.x != 0 && moveDir.y != 0) && MM.map[currentPos.x + moveDir.x, currentPos.y + moveDir.y].TType == TileType.Floor && moveDir != Vector2Int.zero)
            {
                if (!mySR.flipX && moveDir.x < 0)
                    mySR.flipX = true;
                else if (mySR.flipX && moveDir.x > 0)
                    mySR.flipX = false;
                StartCoroutine(MoveToPosition(transform.position + (Vector3Int)moveDir, time));
                currentPos += moveDir;
                firstBeat = false;
                PlayerTurnEnd?.Invoke();
            }
            if((moveDir == Vector2Int.zero || MM.map[currentPos.x + moveDir.x, currentPos.y + moveDir.y].TType != TileType.Floor) && movementEnded)
            {
                myAnim.SetBool("Move", false);
            }
            //Debug.Log("Move : " + moveDir);
            Debug.DrawLine(new Vector3(4,4,0), new Vector3(5, 5, 0), Color.red, 0.1f);
        };

    }

    public IEnumerator MoveToPosition(Vector2 position, float timeToMove)
    {
        yield return new WaitUntil(() => movementEnded);
        movementEnded = false;
        myAnim.SetBool("Move", true);
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector2.Lerp(currentPos, position, t);
            yield return null;
        }
        movementEnded = true;
    }

    bool firstBeat = false, movementEnded = true;
    IEnumerator Move()
    {
        firstBeat = true;
        var tmp = MI.Movement;
        var tmpDir = Vector2Int.RoundToInt(tmp.Movment.ReadValue<Vector2>());
        moveDir = tmpDir;
        do
        {
            yield return new WaitForFixedUpdate();
            tmpDir = Vector2Int.RoundToInt(tmp.Movment.ReadValue<Vector2>());
            moveDir = tmpDir != Vector2Int.zero || !firstBeat ? tmpDir :moveDir;
        } while (moveDir != Vector2Int.zero);
        moving = false;
    }
}