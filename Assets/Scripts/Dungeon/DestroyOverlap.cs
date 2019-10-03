using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverlap : MonoBehaviour
{
    private float waitTime = 4.0f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spawnpoint>())
        {
            Destroy(collision.gameObject);
        }
    }
}
