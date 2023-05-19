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
    public float fireRate = 5f;

    [SerializeField]
    public float blackHoleRate = 30f;

    [SerializeField]
    Timer timer;

    [SerializeField]
    Timer shotTimer;

    [SerializeField]
    GameObject beam;

    [SerializeField]
    GameObject blackHole;

    [SerializeField]
    Transform summonPoint;

    float nextFire;

    float nextHole;

    bool isLiving = true;

    Animator anim;

    PolygonCollider2D abyss;

    FBCharge hole;

    SolarBeam solar;

    GameSession session;

    LevelManager lvlMan;

    float curTime;

    bool charging;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        anim = GetComponent<Animator>();
        session = FindObjectOfType<GameSession>();
        hole = FindObjectOfType<FBCharge>();
        solar = FindObjectOfType<SolarBeam>();
        lvlMan = FindObjectOfType<LevelManager>();
        nextFire = Time.time;
    }

    void Update()
    {
        if (isLiving)
        {
            FireBeam();
        }
        Die();
    }

    void FireBeam()
    {
        nextFire = shotTimer.BossShotCount();
        nextHole = timer.BossHoleCount();

        if (nextFire >= fireRate)
        {
            Instantiate(beam, summonPoint.position, transform.rotation);
            nextFire = 0;
        }

        if (nextHole > blackHoleRate)
        {
            Instantiate(blackHole, summonPoint.position, transform.rotation);
            nextHole = 0;
        }
    }

    void Die()
    {
        if (hitPoints <= 0)
        {
            StartCoroutine(Death());
            StartCoroutine(LoadVictory());
        }
    }

    IEnumerator Death()
    {
        anim.SetBool("Dying", true);
        isLiving = false;
        yield return new WaitForSecondsRealtime(3);
        Destroy (gameObject);
    }

    IEnumerator LoadVictory()
    {
        yield return new WaitForSecondsRealtime(7.5f);
        lvlMan.LoadVictory();
    }
}
