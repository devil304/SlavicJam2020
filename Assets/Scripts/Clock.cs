using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BeatDel();
public class Clock : MonoBehaviour
{
    [SerializeField] float beatTime = 0.5f;
    public static event BeatDel Beat;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(beat());
    }

    IEnumerator beat()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(beatTime);
            Beat?.Invoke();
        }
    }

}
