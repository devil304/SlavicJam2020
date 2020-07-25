using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class counter : MonoBehaviour
{
    float tim = 0;
    string Tim;
    void Update()
    {
        tim += Time.deltaTime;
        Tim = ((int)(tim / 6)).ToString() + '.' + Math.Round(tim, 2).ToString();
        gameObject.GetComponent<TextMeshPro>().text = Tim;
    }
}
