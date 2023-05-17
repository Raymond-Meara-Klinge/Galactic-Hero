using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarBeam : MonoBehaviour
{
    [SerializeField]
    float fireSpd = 7f;

    Rigidbody2D bodied;

    PlayerMove target;

    Vector2 fireDirect;

    [SerializeField]
    int pointsPerKill = 50;

    GameSession session;

    void Awake()
    {
        session = FindObjectOfType<GameSession>();
    }

    void Start()
    {
        bodied = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMove>();
        fireDirect =
            (target.transform.position - transform.position).normalized *
            fireSpd;
        bodied.velocity = new Vector2(fireDirect.x, fireDirect.y);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            session.playHP -= 5f;
        }
        Destroy (gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy (gameObject);
    }
}
