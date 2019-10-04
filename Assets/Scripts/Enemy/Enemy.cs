using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State
    {
        Wander,
        Chase,
        Attack
    }

    // instance refrence
    private PlayerController player;

    // enemy propeties
    private Animator eAnimator;
    public LayoutSpawner layout;

    public float thinkInterval;
    private State curState;

    public int life;
    public int Damage;

    public float walkSpeed;
    public float chaseSpeed;
    private float timer;

    public float senseDistance;
    public float attackDistance;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        eAnimator = GetComponent<Animator>();
        StartCoroutine("MakeDecision");
    }

    private void Update()
    {
        switch (curState)
        {
            case State.Wander:
                Wander();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Attack:
                Attack();
                break;
            default:
                return;
        }
    }

    IEnumerator MakeDecision()
    {
        while (true)
        {
            yield return new WaitForSeconds(thinkInterval);
            Debug.Log("MakeDecision Once!");
            Vector3 distance = player.transform.position - transform.position;
            if (distance.magnitude < attackDistance)
            {
                curState = State.Attack;
                Debug.Log("Attack!");
            }
            else if (distance.magnitude < senseDistance)
            {
                eAnimator.SetBool("isAttack", false);
                curState = State.Chase;
                Debug.Log("Chase!");
            }
            else
            {

                eAnimator.SetBool("isAttack", false);
                curState = State.Wander;
                Debug.Log("Wander!");
            }
        }
    }

    void Wander()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 destination = new Vector3(randomPoint.x, randomPoint.y, 0.0f);
        transform.Translate(destination * walkSpeed * Time.deltaTime);
    }

    void Chase()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * chaseSpeed * Time.deltaTime);
    }

    void Attack()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * chaseSpeed * Time.deltaTime);
        eAnimator.SetBool("isAttack",true);
    }

    // handle damage from player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= player.curWeapon.Damage;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                layout.enemies.Remove(this);
                Destroy(gameObject);
            }
        }else if (collision.gameObject.CompareTag("Knife"))
        {
            life -= player.curWeapon.Damage;
            if(life <= 0)
            {
                layout.enemies.Remove(this);
                Destroy(gameObject);
            }
        }
    }

}
