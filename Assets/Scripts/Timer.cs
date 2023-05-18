using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float chargeTime;

    public float timerVal;

    public float timerVal2;

    public float timerVal3;

    PlayerMove playa;

    FinalBoss boss;

    void Start()
    {
        playa = FindObjectOfType<PlayerMove>();
        boss = FindObjectOfType<FinalBoss>();
        CancelTime();
    }

    void Update()
    {
        if (playa.charging == true)
        {
            Count();
        }
        BossShotCount();
        BossHoleCount();
    }

    public float Count()
    {
        chargeTime = playa.chargeShotTime;
        if (timerVal < chargeTime)
        {
            timerVal += Time.deltaTime;
        }
        else if (timerVal >= chargeTime)
        {
            timerVal = chargeTime;
        }
        return timerVal;
    }

    public float BossShotCount()
    {
        chargeTime = boss.fireRate;
        if (timerVal2 < chargeTime)
        {
            timerVal2 += Time.deltaTime;
        }
        else if (timerVal2 == chargeTime)
        {
            timerVal2 = chargeTime;
        }
        else
        {
            timerVal2 = 0;
        }
        return timerVal2;
    }

    public float BossHoleCount()
    {
        chargeTime = boss.blackHoleRate;
        if (timerVal3 < chargeTime)
        {
            timerVal3 += Time.deltaTime;
        }
        else if (timerVal3 == chargeTime)
        {
            timerVal3 = chargeTime;
        }
                else
        {
            timerVal3 = 0;
        }
        return timerVal3;
    }

    public void CancelTime()
    {
        timerVal = 0;
    }
}
