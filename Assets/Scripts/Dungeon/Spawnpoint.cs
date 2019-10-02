using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public int openDirection;
    // 1 == have top, need bottom
    // 2 == have right, need left
    // 3 == have bottom, need top
    // 4 == have left, need right

    private RoomTempProvider templates;
    private int rand;
    private bool isSpawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("RoomTemps").GetComponent<RoomTempProvider>();
        Invoke("Spawn", 0.1f);
    }
    private void Spawn()
    {
        if (!isSpawned)
        {
            switch (openDirection)
            {
                case 1:
                    // spawn room with bottom opening
                    rand = Random.Range(0, templates.RoomWithBottom.Length);
                    Instantiate(templates.RoomWithBottom[rand], transform);
                    break;
                case 2:
                    // spawn room with left opening
                    rand = Random.Range(0, templates.RoomWithLeft.Length);
                    Instantiate(templates.RoomWithLeft[rand], transform);
                    break;
                case 3:
                    // spawn room with top opening
                    rand = Random.Range(0, templates.RoomWithTop.Length);
                    Instantiate(templates.RoomWithTop[rand], transform);
                    break;
                case 4:
                    // spawn room with right opening
                    rand = Random.Range(0, templates.RoomWithRight.Length);
                    Instantiate(templates.RoomWithRight[rand], transform);
                    break;
                default:
                    return;
            }
        }
        isSpawned = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(collision.GetComponent<Spawnpoint>().isSpawned == false && isSpawned == false)
            {
                Destroy(gameObject);
            }
            isSpawned = true;
        }
    }
}
