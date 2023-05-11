using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float runSpeed = 8f;

    [SerializeField]
    float jumpSpd = 12f;

    [SerializeField]
    float chargeShotTime = 10f;

    [SerializeField]
    Vector2 boing = new Vector2(1f, 0.5f);

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    GameObject chargeProj;

    [SerializeField]
    Transform impact;

    Vector2 moveInput;

    Rigidbody2D bodied;

    Animator anim;

    CapsuleCollider2D myCollider;

    bool isLiving = true;

    float curTime = 0f;

    BoxCollider2D feet;

    ChargeShot cShot;

    void Start()
    {
        cShot = FindObjectOfType<ChargeShot>();
        bodied = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isLiving == true)
        {
            Jumpy();
            Run();
            FlipSprite();
            Die();
        }
        else
        {
            return;
        }
    }

    void OnMove(InputValue value)
    {
        if (!isLiving)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isLiving)
        {
            return;
        }

        if (
            value.isPressed &&
            feet.IsTouchingLayers(LayerMask.GetMask("Platforms"))
        )
        {
            bodied.velocity += new Vector2(0f, jumpSpd);
        }
    }

    public void Jumpy()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {
            anim.SetBool("isJumping", true);
        }
        else if (feet.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {
            anim.SetBool("isJumping", false);
        }
    }

    public void OnFire(InputValue value)
    {
        if (!isLiving)
        {
            return;
        }

        if (value.isPressed)
        {
            Instantiate(projectile, impact.position, transform.rotation);
            anim.SetBool("isFiring", true);
        }
        if (
            anim.GetBool("isFiring") == true &&
            anim.GetBool("isRunning") == true
        )
        {
            anim.SetBool("isFiring", false);
        }
    }

    void OnChargeFire(InputValue value)
    {
        if (!isLiving)
        {
            return;
        }
        if (!anim.GetBool("chargingFire") && value.isPressed)
        {
            StartCoroutine(Timer(value.isPressed));
        }
        else
        {
            anim.SetBool("chargingFire", false);
            anim.SetBool("isFiring", true);
            Instantiate(chargeProj, impact.position, transform.rotation);
            bodied.velocity = boing;
        }
    }

    IEnumerator Timer(bool holding)
    {
        curTime += Time.deltaTime;
        bool counting = true;
        anim.SetBool("chargingFire", true);
        if (holding)
        {
            if (counting == true)
            {
                Debug.Log (curTime);
            }
            if (curTime >= chargeShotTime)
            {
                counting = false;
            }
        }
        yield return new WaitForSecondsRealtime(chargeShotTime);
    }


    void Run()
    {
        bool moved = Mathf.Abs(bodied.velocity.x) > Mathf.Epsilon;
        Vector2 playVelocity =
            new Vector2(moveInput.x * runSpeed, bodied.velocity.y);
        bodied.velocity = playVelocity;
        if (moved && feet.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {
            anim.SetBool("isRunning", moved);
            anim.SetBool("isFiring", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Die()
    {
        if (
            myCollider
                .IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards"))
        )
        {
            isLiving = false;
            anim.SetTrigger("Dead");
            anim.SetBool("isRunning", false);
            anim.SetBool("isFiring", false);
            anim.SetBool("isJumping", false);
            Object.Destroy (myCollider);
            FindObjectOfType<GameSession>().PlayDeaths();
        }
    }

    void FlipSprite()
    {
        bool HorSpeed = Mathf.Abs(bodied.velocity.x) > Mathf.Epsilon;
        if (HorSpeed)
        {
            transform.localScale =
                new Vector2((Mathf.Sign(bodied.velocity.x)), 1f);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
