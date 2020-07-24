using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2Int currentPos;
    MainInput MI;
    Vector2Int moveDir = new Vector2Int(0,0);
    bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        MI = new MainInput();
        MI.Enable();
        MI.Movement.updown.performed += perf => {
            if (!moving)
            {
                moving = true;
                StartCoroutine(Move());
            }
        };
        MI.Movement.leftright.performed += perf => {
            if (!moving)
            {
                moving = true;
                StartCoroutine(Move());
            }
        };

        Clock.Beat += () => {
            BeatT = true;
            Debug.Log("Clock");
            i++;
        };

    }
    bool BeatT = false;
    int i = 0, x = 0;
    IEnumerator Move()
    {

        do
        {
            moveDir = new Vector2Int((int)MI.Movement.leftright.ReadValue<float>(), (int)MI.Movement.updown.ReadValue<float>());
            Debug.Log("Move : "+moveDir);
            yield return new WaitUntil(() => BeatT);
            if(x==0)
                x = i;
            else
                x++;
            BeatT = false;
            if (x < i - 1)
            {
                Debug.LogWarning("Skip i: "+i+" x: "+x);
                x = i;
            }
        } while (moveDir != Vector2Int.zero);
        moving = false;
        x = 0;
    }
}
