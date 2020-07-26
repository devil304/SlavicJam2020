using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class counter : MonoBehaviour
{
    public float tim = 0;
    TextMeshProUGUI tmp;
    public bool trig = false;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (trig)
        {
            tim += Time.deltaTime;
            UpdateC();
        }
       //PlayerPrefs.SetString("Time", tmp.text);
    }
    public void UpdateC()
    {
        tmp.text = ((int)(tim / 60)).ToString() + ':' + Math.Round(tim - (((int)(tim / 60)) * 60), 2).ToString();
    }
}
