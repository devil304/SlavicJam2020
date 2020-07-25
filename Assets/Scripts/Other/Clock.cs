﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BeatDel();
public class Clock : MonoBehaviour
{
    public float beatTime = 0.5f, delay = 0;
    public static event BeatDel Beat;
    [SerializeField] AudioSource AS;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        AS.PlayScheduled(0);
        StartCoroutine(beat());
    }

    IEnumerator beat()
    {
        yield return new WaitForSecondsRealtime(delay);
        while (true)
        {
            yield return new WaitForSecondsRealtime(beatTime);
            Beat?.Invoke();
        }
    }

}