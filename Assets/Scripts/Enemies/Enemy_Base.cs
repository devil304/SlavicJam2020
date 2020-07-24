using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    public void MoveToDirection(Vector2 direction, Action moveFinishedCallback)
    {
        var x = direction.x > 0 ? Mathf.Ceil(direction.x) : Mathf.Floor(direction.x);
        var y = direction.y > 0 ? Mathf.Ceil(direction.y) : Mathf.Floor(direction.y);
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            transform.position += new Vector3(x, 0);
        } 
        else
        {
            transform.position += new Vector3(0, y);
        }

        moveFinishedCallback?.Invoke();
    }
}
