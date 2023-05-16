using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float chargeTime;

    float timerVal;

    PlayerMove playa;

    void Start()
    {
        playa = FindObjectOfType<PlayerMove>();
        CancelTime();
        chargeTime = playa.chargeShotTime;
    }

    void Update()
    {
        Count();
    }

    public float Count()
    {
        if (timerVal < chargeTime)
        {
            timerVal += Time.deltaTime;
            Debug.Log(timerVal);
        }
        else if (timerVal >= chargeTime)
        {
            timerVal = chargeTime;
        }
            return timerVal;
    }

    public void CancelTime()
    {
        timerVal = 0;
    }
}
