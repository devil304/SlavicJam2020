using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    float time = 0.5f;

    private void Start()
    {
        time = FindObjectOfType<Clock>().beatTime;
    }

    public IEnumerator MoveToDirection(Vector2 direction, Action FinishedCallback)
    {
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

        FinishedCallback?.Invoke();
    }
}
