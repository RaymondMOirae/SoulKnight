using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCase : MonoBehaviour
{
    private int goldNum;
    private int ligeNum;
    public bool picked;
    public AudioClip bonusSound;

    void Start()
    {
        goldNum = Random.Range(8, 15);
        ligeNum = Random.Range(3, 6);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !picked)
        {

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.goldNum += goldNum;
            player.life += ligeNum;
            SoundManager.theSoundManager.PlayClip(bonusSound);
            picked = true;
        }
    }
}
