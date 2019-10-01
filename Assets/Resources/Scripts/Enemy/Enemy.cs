using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // instance refrence
    public PlayerController player;

    // enemy propeties
    public int life;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= player.curWeapon.Damage;
            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }
        Debug.Log("Collision!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= player.curWeapon.Damage;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
        Debug.Log("Trigger!");
    }
}
