using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // instance reference
    private PlayerController player;

    // enemy properties
    private Animator eAnimator;
    public LayoutSpawner layout;
    public GameObject bullet;

    public AudioClip dieSound;
    public AudioClip attackSound;


    public float thinkInterval;
    public bool isShooter;
    public bool isBoss;

    public int life;
    public int Damage;

    public float moveSpeed;

    public float walkSpeed;
    public float chargeSpeed;
    public float bulletSpeed;

    public float attackDistance;
    public float senseDistance;

    // temporary values
    public Vector3 moveDirection;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        eAnimator = GetComponent<Animator>();
        StartCoroutine("MakeDecision");
    }

    private void Update()
    {
        ExcecuteMovement();
    }

    IEnumerator MakeDecision()
    {
        while (true)
        {
            yield return new WaitForSeconds(thinkInterval);

            Vector3 distance = player.transform.position - transform.position;
            if (distance.magnitude < attackDistance)
            {
                eAnimator.SetBool("isAttack", true);
                if (isShooter || isBoss)
                {
                    StartCoroutine("Shoot");
                }
                if(!isShooter)
                {
                    moveDirection = GetPlayerDirection();
                    moveSpeed = chargeSpeed;
                    StartCoroutine("Charge");
                }
            }
            else if(distance.magnitude < senseDistance)
            {
                eAnimator.SetBool("isAttack", false);
                moveDirection = GetRandomDirection();
            }
            else
            {
                moveDirection = Vector3.zero; 
                eAnimator.SetBool("isAttack", false);
            }
        }
    }
    void ExcecuteMovement()
    {
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        SoundManager.theSoundManager.PlayClip(attackSound);
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.up= player.transform.position - transform.position;
        newBullet.GetComponent<Rigidbody2D>().velocity =(player.transform.position - transform.position).normalized * bulletSpeed;
    }

    IEnumerator Charge()
    {
        SoundManager.theSoundManager.PlayClip(attackSound);
        yield return new WaitForSeconds(1.5f);
        moveSpeed = walkSpeed;
    }

    Vector3 GetRandomDirection()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 destination = new Vector3(randomPoint.x, randomPoint.y, 0.0f);
        return destination;
    }

    Vector3 GetPlayerDirection()
    {
        return (player.transform.position - transform.position).normalized;
    }

    // handle damage from player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            life -= player.curWeapon.Damage;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                layout.enemies.Remove(this);
                Destroy(gameObject);
                SoundManager.theSoundManager.PlayClip(dieSound);
            }
        }
        else if (collision.CompareTag("Knife"))
        {
            life -= player.curWeapon.Damage;
            if (life <= 0)
            {
                layout.enemies.Remove(this);
                Destroy(gameObject);
                SoundManager.theSoundManager.PlayClip(dieSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Player") && !isShooter)
        {
            player.life -= Damage;
        }
    }

}
