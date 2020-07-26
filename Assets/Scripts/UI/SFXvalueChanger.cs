using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXvalueChanger : MonoBehaviour
{
    inGameSettings iGS;
    private void Awake()
    {
        iGS = FindObjectOfType<inGameSettings>();
        GetComponent<Slider>().value = iGS.SFXValue;
    }

    public void valChange(float val)
    {
        iGS.SFXChange(val);
        PlayerPrefs.SetFloat("SFXValue", val);
    }
}
