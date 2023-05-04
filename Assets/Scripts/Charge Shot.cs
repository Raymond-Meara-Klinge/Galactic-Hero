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
    public float chargeTimer = 3f;

    GameSession session;

    public float currentTime = 0f;

    void Awake()
    {
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
        currentTime += .001f;
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
        if (killed >= 3)
        {
            Destroy (gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy (gameObject);
    }
}