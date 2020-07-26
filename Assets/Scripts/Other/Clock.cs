using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BeatDel();
public class Clock : MonoBehaviour
{
    public float beatTime = 0.5f, delay = 0;
    public static event BeatDel Beat;
    [SerializeField] AudioSource AS;
    private void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForFixedUpdate();
        AS.PlayScheduled(0);
        StartCoroutine(beat());
    }
    void OnDestroy()
    {
        Beat = null;
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
