using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public void action()
    {
        Transform current = gameObject.GetComponent<Transform>();
        while (current.parent.parent != null)
        {
            current = current.parent;
        }
        panel.SetActive(true);
        current.gameObject.SetActive(false);
    }
}
