using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
LevelManager lvlMan;

    int starNum;

    int bossNum;

    void Awake() 
    {
        starNum = GameObject.FindGameObjectsWithTag("Starling").Length;
        bossNum = GameObject.FindGameObjectsWithTag("Boss").Length;
        lvlMan = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        Check();
    }

    void Check()
    {
        Debug.Log(starNum);
        Debug.Log(bossNum);
        if ( starNum <= 0 && bossNum <= 0)
        {
            lvlMan.LoadNext();
        }
    }
}
