using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemMove : MonoBehaviour
{
    [SerializeField]
    float moveSpd = -1f;

    Rigidbody2D bodied;

    void Start()
    {
        bodied = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bodied.velocity = new Vector2(moveSpd, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveSpd = -moveSpd;
        FlipFace();
    }

        void FlipFace()
    {
        bool HorSpeed = Mathf.Abs(bodied.velocity.x) > Mathf.Epsilon;
        if (HorSpeed)
        {
            transform.localScale =
                new Vector2(-(Mathf.Sign(bodied.velocity.x)), 1f);
        }
    }

}
