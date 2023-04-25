using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroll : MonoBehaviour
{
    [SerializeField] Vector2 moveSpd;

    Vector2 offset;
    Material mat;
    void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = moveSpd * Time.deltaTime;
        mat.mainTextureOffset += offset;
    }
}
