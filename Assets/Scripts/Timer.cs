using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float questionTime = 5f;

    public float fillFrac;

    public float timerVal;

    void Update()
    {
        TimerUpdate();
    }

    public void CancelTime()
    {
        timerVal = 0;
    }

    void TimerUpdate()
    {
        timerVal -= Time.time;

            if (timerVal > 0)
            {
                fillFrac = timerVal / questionTime;
            }
            Debug.Log(timerVal);
    }
}
