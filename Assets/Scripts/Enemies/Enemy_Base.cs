using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    public MapMapper MM { get; set; }
    public Animator Animator { get; set; }
    public SpriteRenderer SpriteRenderer { get; set; }
    float time;
    
    public void Start()
    {
        MM = FindObjectOfType<MapMapper>();
        time = FindObjectOfType<Clock>().beatTime - 0.1f;
        Animator = GetComponent<Animator>();
        Animator.SetFloat("Speed", (1f / (time / 2f)));
        SpriteRenderer = GetComponent<SpriteRenderer>();
        MM.enemylist++;
        //Debug.Log(MM.enemylist);
    }

    public IEnumerator MoveToDirection(Vector2 direction, Action FinishedCallback)
    {
        Animator.SetBool("Move", true);
        var x = direction.x > 0 ? Mathf.Ceil(direction.x) : Mathf.Floor(direction.x);
        var y = direction.y > 0 ? Mathf.Ceil(direction.y) : Mathf.Floor(direction.y);

        if (x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else
        {
            SpriteRenderer.flipX = true;
        }

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(x / 2 , 0);
            CheckIfHit();
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(x / 2, 0);
            yield return new WaitForSecondsRealtime(0.1f);
        } 
        else
        {
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(0, y / 2);
            CheckIfHit();
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(0, y / 2);
            yield return new WaitForSecondsRealtime(0.1f);
        }

        Animator.SetBool("Move", false);
        FinishedCallback?.Invoke();
    }

    public void CheckIfHit()
    {
        for(int i = 0; i < MM.pros.Count; i++)
        {
            if(Vector2Int.RoundToInt(MM.pros[i].transform.position) == Vector2Int.RoundToInt(transform.position))
            {
                var tmp = MM.pros[i];
                Player.PlayerTurnEnd -= MM.pros[i].MoveVinyl;
                MM.pros.Remove(MM.pros[i]);
                Destroy(tmp.gameObject);
                MM.enemylist--;
                //Debug.Log(MM.enemylist);
                Animator.SetBool("Dance", true);
                Destroy(this);
                break;
            }
        }
    }
}
