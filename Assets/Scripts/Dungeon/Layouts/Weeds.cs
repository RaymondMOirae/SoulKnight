using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weeds : MonoBehaviour
{
    //public int life = 4;
    //public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<PlayerController>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Knife"))
        //{
        //    life -= player.curWeapon.Damage;
        //    if(life <= 0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
