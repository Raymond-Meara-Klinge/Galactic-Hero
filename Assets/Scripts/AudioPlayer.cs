using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    void Awake()
    {
        ManageSingle();
    }

    void ManageSingle()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
