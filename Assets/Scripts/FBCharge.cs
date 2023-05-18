using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBCharge : MonoBehaviour
{
    [SerializeField]
    float fireSpd = 5f;

    Rigidbody2D bodied;

    PlayerMove target;

    float xSpd;

    [SerializeField]
    float lifetime = 5f;

    GameSession session;

    Timer timer;

    float currentTime = 0f;

    Vector2 fireDirect;

    void Awake()
    {
        session = FindObjectOfType<GameSession>();
        timer = FindObjectOfType<Timer>();
    }

    void Start()
    {
        bodied = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMove>();
        xSpd = target.transform.localScale.x * fireSpd;
        bodied = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMove>();
        fireDirect =
            (target.transform.position - transform.position).normalized *
            fireSpd;
        bodied.velocity = new Vector2(fireDirect.x, fireDirect.y);
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            session.playHP -= 15;
        }
        Destroy (gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy (gameObject);
    }
}
