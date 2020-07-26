using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MUSICvalueChange : MonoBehaviour
{
    inGameSettings iGS;
    private void Awake()
    {
        iGS = FindObjectOfType<inGameSettings>();
        GetComponent<Slider>().value = iGS.MUSICValue;
    }

    public void valChange(float val)
    {
        iGS.MusicChange(val);
        PlayerPrefs.SetFloat("MUSICValue", val);
    }
}