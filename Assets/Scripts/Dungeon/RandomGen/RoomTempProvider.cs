using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTempProvider: MonoBehaviour
{

    public GameObject[] RoomWithBottom;
    public GameObject[] RoomWithLeft;
    public GameObject[] RoomWithTop;
    public GameObject[] RoomWithRight;
    public GameObject DoorSealer;
    public GameObject bossRoom;
    public GameObject exit;

    public List<GameObject> spawnedRooms = new List<GameObject>();

    public bool spawnedSpecial;

    public float specialRoomTimer = 4;

    private void Update()
    {
        specialRoomTimer -= Time.deltaTime;
        if(specialRoomTimer < 0 && !spawnedSpecial)
        {
            SpawnSpecialRooms();
        }
    }

    void SpawnSpecialRooms()
    {
        // alter the last spawned room to exit room
        GameObject lastRoom = spawnedRooms[spawnedRooms.Count - 1];
        int childNum = lastRoom.transform.childCount;
        Destroy(lastRoom.transform.GetChild(childNum - 2).gameObject);
        Instantiate(bossRoom, lastRoom.transform);

        // alter a random room to store / bonus room
        // TODO TODO TODO TODO TODO
        // TODO TODO TODO TODO TODO
        spawnedSpecial = true; 
    }
}
