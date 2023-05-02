using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    float fireSpd = 5f;

    Rigidbody2D bodied;

    PlayerMove playa;

    float xSpd;

    [SerializeField]
    int pointsPerKill = 50;

    void Start()
    {
        bodied = GetComponent<Rigidbody2D>();
        playa = FindObjectOfType<PlayerMove>();
        xSpd = playa.transform.localScale.x * fireSpd;
    }

    void Update()
    {
        bodied.velocity = new Vector2(xSpd, 0f);
    }

    void FlipSprite()
    {
        bool HorSpeed = Mathf.Abs(bodied.velocity.x) > Mathf.Epsilon;
        if (HorSpeed)
        {
            transform.localScale =
                new Vector2(-(Mathf.Sign(bodied.velocity.x)), 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameSession>().Scoring(pointsPerKill);
        }
        Destroy (gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy (gameObject);
    }
}
