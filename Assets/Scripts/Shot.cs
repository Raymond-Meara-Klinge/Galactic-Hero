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
    ParticleSystem stars;

    [SerializeField]
    int pointsPerKill = 50;

    [SerializeField]
    int pointsPerBossHit = 75;

    GameSession session;

    FinalBoss boss;

    void Awake()
    {
        boss = FindObjectOfType<FinalBoss>();
        session = FindObjectOfType<GameSession>();
    }

    void Start()
    {
        bodied = GetComponent<Rigidbody2D>();
        playa = FindObjectOfType<PlayerMove>();
        xSpd = playa.transform.localScale.x * fireSpd;
    }

    void Update()
    {
        bodied.velocity = new Vector2(xSpd, 0f);
        FlipSprite();
    }

    void Stars()
    {
        stars.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Starling")
        {
            Destroy(other.gameObject);
            session.Scoring (pointsPerKill);
            UpdateStarNum();
        }
        else if (other.tag == "Boss")
        {
            boss.hitPoints -= 5;
            session.Scoring (pointsPerBossHit);
        }
        Destroy (gameObject);
    }

    public void UpdateStarNum()
    {
        session.starNum--;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy (gameObject);
    }

    void FlipSprite()
    {
        bool HorSpeed = Mathf.Abs(bodied.velocity.x) > Mathf.Epsilon;
        if (HorSpeed)
        {
            stars.transform.localScale =
                new Vector2((Mathf.Sign(bodied.velocity.x)), 1f);
        }
    }
}
