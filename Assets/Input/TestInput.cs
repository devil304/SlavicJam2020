using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    MainInput myIA;
    // Start is called before the first frame update
    void Start()
    {
        myIA = new MainInput();
        myIA.Enable();

        myIA.nam.na.performed += perf => {
            Debug.Log("W");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
