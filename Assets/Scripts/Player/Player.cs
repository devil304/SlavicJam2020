using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PT();
public class Player : MonoBehaviour
{
    public static event PT PlayerTurnEnd;
    public Vector2Int currentPos;
    public MainInput MI;
    Vector2Int moveDir = Vector2Int.zero, attacDir = Vector2Int.zero;
    bool moving = false, attacking = false;
    MapMapper MM;
    Animator myAnim;
    SpriteRenderer mySR;
    [SerializeField] GameObject plate;
    float time;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerTurnEnd = null;
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
            if (!attacking)
            {
                attacking = true;
                StartCoroutine(Attac());
            }
        };

        Clock.Beat += () => {
            if (!(moveDir.x != 0 && moveDir.y != 0) && moveDir != Vector2Int.zero && CurrentAction && MM.map[currentPos.x + moveDir.x, currentPos.y + moveDir.y].TType == TileType.Floor)
            {
                if (!mySR.flipX && moveDir.x < 0)
                    mySR.flipX = true;
                else if (mySR.flipX && moveDir.x > 0)
                    mySR.flipX = false;
                currentPos += moveDir;
                StartCoroutine(MoveToPosition(moveDir, time));
                firstBeat = false;
            }
            else if (!(attacDir.x != 0 && attacDir.y != 0) && attacDir != Vector2Int.zero && !CurrentAction && MM.map[currentPos.x + attacDir.x, currentPos.y + attacDir.y].TType == TileType.Floor)
            {
                if (!mySR.flipX && attacDir.x < 0)
                    mySR.flipX = true;
                else if (mySR.flipX && attacDir.x > 0)
                    mySR.flipX = false;
                firstBeat = false;
                StartCoroutine(Attack(attacDir));
            }
            if((moveDir == Vector2Int.zero || MM.map[currentPos.x + moveDir.x, currentPos.y + moveDir.y].TType != TileType.Floor) && movementEnded)
            {
                myAnim.SetBool("Move", false);
            }
            //Debug.Log("Move : " + moveDir);
            Debug.DrawLine(new Vector3(4,4,0), new Vector3(5, 5, 0), Color.red, 0.1f);
        };
        StartCoroutine(danceCheck());
    }

    public IEnumerator Attack(Vector2Int pos)
    {
        PlayerTurnEnd?.Invoke();
        myAnim.SetBool("Shoot", true);
        yield return new WaitForSecondsRealtime(time);
        myAnim.SetBool("Shoot", false);
        var tmp = Instantiate(plate, (Vector3Int)(currentPos + pos), Quaternion.identity).GetComponent<vinyl>();
        tmp.dir = pos;
        tmp.MM = MM;
        tmp.time = time;
        PlayerTurnEnd += tmp.MoveVinyl;
        MM.pros.Add(tmp);
    }

    public IEnumerator MoveToPositionCam(Vector3 position, float timeToMove, Transform target)
    {
        position.z = target.position.z;
        yield return new WaitForSecondsRealtime(timeToMove/2);
        yield return new WaitUntil(()=> !cameraMoving);
        cameraMoving = true;
        var currentPos = target.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            target.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
        cameraMoving = false;
    }

    IEnumerator danceCheck()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitUntil(()=>MM.enemylist<=0);
        MI.Disable();
        myAnim.SetBool("Dance", true);
        MM.WIn();
        Destroy(this);
    }

    public IEnumerator MoveToPosition(Vector2 position, float timeToMove)
    {
        PlayerTurnEnd?.Invoke();
        StartCoroutine(MoveToPositionCam((Vector3Int)currentPos, timeToMove, Camera.main.transform));
        yield return new WaitUntil(() => movementEnded);
        movementEnded = false;
        myAnim.SetBool("Move", true);
        yield return new WaitForSecondsRealtime(timeToMove/2);
        transform.position += (Vector3)(position/2);
        yield return new WaitForSecondsRealtime(timeToMove / 2);
        transform.position += (Vector3)(position / 2);
        movementEnded = true;
    }

    bool firstBeat = false, movementEnded = true, CurrentAction = true, cameraMoving = false;
    IEnumerator Move()
    {
        firstBeat = true;
        CurrentAction = true;
        var tmp = MI.Movement;
        var tmpDir = Vector2Int.RoundToInt(tmp.Movment.ReadValue<Vector2>());
        moveDir = tmpDir;
        do
        {
            yield return new WaitForFixedUpdate();
            tmpDir = Vector2Int.RoundToInt(tmp.Movment.ReadValue<Vector2>());
            if (!CurrentAction && tmpDir != moveDir)
                CurrentAction = true;
            moveDir = tmpDir != Vector2Int.zero || !firstBeat ? tmpDir :moveDir;
        } while (moveDir != Vector2Int.zero);
        moving = false;
    }
    IEnumerator Attac()
    {
        firstBeat = true;
        CurrentAction = false;
        var tmp = MI.Movement;
        var tmpDir = Vector2Int.RoundToInt(tmp.Attack.ReadValue<Vector2>());
        attacDir = tmpDir;
        do
        {
            yield return new WaitForFixedUpdate();
            tmpDir = Vector2Int.RoundToInt(tmp.Attack.ReadValue<Vector2>()); 
            if (CurrentAction && tmpDir != attacDir)
                CurrentAction = false;
            attacDir = tmpDir != Vector2Int.zero || !firstBeat ? tmpDir : attacDir;
        } while (attacDir != Vector2Int.zero);
        attacking = false;
    }
}