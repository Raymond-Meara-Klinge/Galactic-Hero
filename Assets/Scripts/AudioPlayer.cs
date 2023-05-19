using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClip chargeSFX;

    [SerializeField]
    AudioClip shotSFX;

    void Awake()
    {
        ManageSingle();
    }

    public void PlayChargeClip()
    {
        AudioSource
            .PlayClipAtPoint(chargeSFX, Camera.main.transform.position, 1);
    }

    public void PlayShotClip()
    {
        AudioSource.PlayClipAtPoint(shotSFX, Camera.main.transform.position, 1);
    }

    void ManageSingle()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy (gameObject);
        }
        else
        {
            DontDestroyOnLoad (gameObject);
        }
    }
}
