using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCase : MonoBehaviour
{
    public int goldNum;
    public bool picked;

    void Start()
    {
        goldNum = Random.Range(8, 15);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !picked)
        {
            collision.gameObject.GetComponent<PlayerController>().goldNum += goldNum;
            picked = true;
        }
    }
}
