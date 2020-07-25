﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    public MapMapper MM { get; set; }
    public Animator Animator { get; set; }
    float time;
    
    public void Start()
    {
        MM = FindObjectOfType<MapMapper>();
        time = FindObjectOfType<Clock>().beatTime;
        Animator = GetComponent<Animator>();
    }

    public IEnumerator MoveToDirection(Vector2 direction, Action FinishedCallback)
    {
        Animator.SetBool("Move", true);
        var x = direction.x > 0 ? Mathf.Ceil(direction.x) : Mathf.Floor(direction.x);
        var y = direction.y > 0 ? Mathf.Ceil(direction.y) : Mathf.Floor(direction.y);
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(x / 2 , 0);
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(x / 2, 0);
        } 
        else
        {
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(0, y / 2);
            yield return new WaitForSecondsRealtime(time / 2);
            transform.position += new Vector3(0, y / 2);
        }

        Animator.SetBool("Move", false);
        FinishedCallback?.Invoke();
    }

    public void CheckIfHit()
    {
        for(int i = 0; i < MM.pros.Count; i++)
        {
            if(MM.pros[i].transform.position == transform.position)
            {
                Destroy(gameObject);
            }
        }
    }
}
