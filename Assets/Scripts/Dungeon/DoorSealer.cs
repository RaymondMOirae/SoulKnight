using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSealer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("Destroy! T Enter");
        if (collision.gameObject.CompareTag("DoorSealer"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.05f);
        }
    }
}
