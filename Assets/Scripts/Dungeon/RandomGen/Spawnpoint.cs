﻿using System.Collections;
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
    public bool isSpawned = false;
    private float waitTime = 3.0f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("RoomTemps").GetComponent<RoomTempProvider>();
        Invoke("Spawn", 0.1f);
    }
    private void Spawn()
    {
        if (!isSpawned)
        {
            GameObject room;
            switch (openDirection)
            {
                case 1:
                    // spawn room with bottom opening
                    rand = Random.Range(0, templates.RoomWithBottom.Length);
                    room = Instantiate(templates.RoomWithBottom[rand], transform.position, Quaternion.identity);
                    templates.spawnedRooms.Add(room);
                    break;
                case 2:
                    // spawn room with left opening
                    rand = Random.Range(0, templates.RoomWithLeft.Length);
                    room = Instantiate(templates.RoomWithLeft[rand], transform.position, Quaternion.identity);
                    templates.spawnedRooms.Add(room);
                    break;
                case 3:
                    // spawn room with top opening
                    rand = Random.Range(0, templates.RoomWithTop.Length);
                    room = Instantiate(templates.RoomWithTop[rand], transform.position, Quaternion.identity);
                    templates.spawnedRooms.Add(room);
                    break;
                case 4:
                    // spawn room with right opening
                    rand = Random.Range(0, templates.RoomWithRight.Length);
                    room = Instantiate(templates.RoomWithRight[rand], transform.position, Quaternion.identity);
                    templates.spawnedRooms.Add(room);
                    break;
            }
            isSpawned = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<Spawnpoint>().isSpawned == true && isSpawned == false)
            {
                Destroy(gameObject);
            }
            isSpawned = true;
        }
    }
}
