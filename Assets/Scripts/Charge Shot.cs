using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : MonoBehaviour
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
    float lifetime = 5f;

    GameSession session;

    FinalBoss boss;

    Timer timer;

    float currentTime = 0f;

    void Awake()
    {
        boss = FindObjectOfType<FinalBoss>();
        session = FindObjectOfType<GameSession>();
        timer = FindObjectOfType<Timer>();
        playa = FindObjectOfType<PlayerMove>();
    }

    void Start()
    {
        bodied = GetComponent<Rigidbody2D>();
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
        int killed = 0;
        if (other.tag == "Starling")
        {
            Destroy(other.gameObject);
            session.Scoring (pointsPerKill);
            session.starNum--;
            killed++;
        }
        else if (other.tag == "Boss")
        {
            boss.hitPoints -= 15;
        }
        if (killed >= 3)
        {
            Destroy (gameObject);
        }
        Destroy (gameObject);
    }

    void KillIt()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= lifetime)
        {
            Destroy(gameObject, 5f);
            currentTime = 0;
        }
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy (gameObject);
    }
}
