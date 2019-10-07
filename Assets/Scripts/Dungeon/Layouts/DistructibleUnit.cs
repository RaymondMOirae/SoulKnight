using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistructibleUnit : MonoBehaviour
{
    public int life = 8;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= player.curWeapon.Damage;
            Destroy(collision.gameObject);
            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
