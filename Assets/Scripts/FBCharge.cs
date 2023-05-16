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
    }

    void Update()
    {
        bodied.velocity = new Vector2(xSpd, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            session.playHP -= 15;
        }
        Destroy (gameObject);
    }

    void KillIt()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= lifetime)
        {
            Destroy(Instantiate(gameObject,
            transform.position,
            Quaternion.identity),
            5f);
            currentTime = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy (gameObject);
    }
}
