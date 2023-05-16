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

    void Awake()
    {
        session = FindObjectOfType<GameSession>();
        hole = FindObjectOfType<FBCharge>();
        solar = FindObjectOfType<SolarBeam>();
        nextFire = Time.time;
    }

    void FireBeam(Collider2D other)
    {
        if (Time.time > nextFire)
        {
            Instantiate(beam, summonPoint.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
