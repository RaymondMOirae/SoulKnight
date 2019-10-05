using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    // Weapon Propeties
    public bool isKnife;
    public string Name;
    public float FireRate;
    public int Damage;
    public bool isKept;
    public int id;

    // Gun Propeties
    public float BulletSpeed;

    // Knife Propeties
    public AnimationCurve curve;
    private bool isAttack = false;
    public float Amplitude;
    public float AttackTime;
    private float timer;

    // instance refrence
    public GameObject Bullet;
    public WeaponManager wManager;

    // temporary values
    private float NextFire;
    private float spriteWidth;

    private void Start()
    {
        wManager = GameObject.Find("WeaponManager").GetComponent<WeaponManager>();
        if (!isKnife)
        {
            // calculate bullet spawn position offset from sprite pivot
            Sprite gunSprite = GetComponent<SpriteRenderer>().sprite;
            spriteWidth = gunSprite.bounds.size.x * transform.localScale.x;
        }
    }

    private void Update()
    {
        if (isKept)
        {
            if (isAttack)
            {
                timer += Time.deltaTime * 2;
                transform.Rotate(0.0f, 0.0f, curve.Evaluate(timer/AttackTime) * Amplitude);
            }else
            {
                RotateToAimCursor();
            }
        }
    }

    public void Attack()
    {
        NextFire += Time.fixedDeltaTime;

        if (NextFire > FireRate)
        {
            if (isKnife)
            {
                KnifeFight();
            }
            else
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        // calculate bullet position and rotation
        Vector3 shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Quaternion bulletRotation = transform.rotation * Quaternion.Euler(0.0f, 0.0f, 90.0f);
        Vector3 spawnPos = transform.position + transform.right * spriteWidth * 0.75f;

        // spawn bullet and add velocity
        GameObject bullet = Instantiate(Bullet, spawnPos, bulletRotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * BulletSpeed;

        // store the bullet in a parent object 
        bullet.transform.SetParent(GameObject.Find("Bullets").transform);

        // reset timer
        NextFire = 0;
    }

    private void KnifeFight()
    {
        if (!isAttack)
        {
            StartCoroutine("RotateKnife");
        }
        isAttack = true;
    }

    IEnumerator RotateKnife()
    {
        yield return new WaitForSeconds(AttackTime);
        isAttack = false;
        timer = 0;
    }

    public void RotateToAimCursor()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.right = new Vector3(direction.x, direction.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wManager.AddWeapon(this);
            Destroy(gameObject);
        }
    }
}
