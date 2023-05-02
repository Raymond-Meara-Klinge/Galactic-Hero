using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        int Pers = FindObjectsOfType<ScenePersist>().Length;
        if (Pers > 1)
        {
            Destroy (gameObject);
        }
        else
        {
            DontDestroyOnLoad (gameObject);
        }
    }
    public void ResetPersist()
    {
        Destroy(gameObject);
    }

}
