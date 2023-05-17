using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [SerializeField]
    public float hitPoints = 200f;

    [SerializeField]
    int pointsForKill = 1500;

    [SerializeField]
    float fireRate = 5f;

    [SerializeField]
    float blackHoleRate = 30f;

    [SerializeField]
    Timer timer;

    [SerializeField]
    GameObject beam;

    [SerializeField]
    GameObject blackHole;

    [SerializeField]
    Transform summonPoint;

    [SerializeField]
    public float chargeShotTime = 3f;

    float nextFire;

    Animator anim;

    PolygonCollider2D abyss;

    FBCharge hole;

    SolarBeam solar;

    GameSession session;

    float curTime;

    bool charging;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        anim = GetComponent<Animator>();
        session = FindObjectOfType<GameSession>();
        hole = FindObjectOfType<FBCharge>();
        solar = FindObjectOfType<SolarBeam>();
        nextFire = Time.time;
    }

    void Update()
    {
        FireBeam();
        Die();
    }

    void FireBeam()
    {
        nextFire = Time.time;
        if (Time.time > nextFire)
        {
            Instantiate(beam, summonPoint.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
        else if (Time.time > chargeShotTime)
        {
            Instantiate(blackHole, summonPoint.position, transform.rotation);
            nextFire = Time.time + fireRate;
            ResetTimer();
        }
    }

    void Die()
    {
        if (hitPoints <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        anim.SetBool("Dying", true);
        yield return new WaitForSecondsRealtime(3);
        Destroy (gameObject);
    }

    void ResetTimer()
    {
        nextFire = 0f;
    }
}
