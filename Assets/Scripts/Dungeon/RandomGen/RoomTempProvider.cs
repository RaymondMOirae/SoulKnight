using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTempProvider: MonoBehaviour
{

    public GameObject[] RoomWithBottom;
    public GameObject[] RoomWithLeft;
    public GameObject[] RoomWithTop;
    public GameObject[] RoomWithRight;
    public Enemy boss;
    public GameObject exit;
    public GameObject bigBonusCase;

    public List<GameObject> spawnedRooms = new List<GameObject>();

    public bool spawnedSpecial = false;

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
        ReplaceLayoutSpawner(exit, spawnedRooms.Count - 1);

        // alter a random room to bonus room
        ReplaceLayoutSpawner(bigBonusCase, Random.Range(0, spawnedRooms.Count - 1));

        spawnedSpecial = true; 

        // alter a random room to boss room
        GameObject randRoom = spawnedRooms[Random.Range(0, spawnedRooms.Count - 1)].gameObject;
        LayoutSpawner layout = GetLayoutSpawner(randRoom);
        Enemy spawnedBoss = Instantiate(boss, randRoom.transform);
        spawnedBoss.layout = layout;
        layout.enemies.Add(spawnedBoss);
        spawnedRooms.Remove(randRoom);
    }

    void ReplaceLayoutSpawner(GameObject replacement, int roomIndex)
    {
        GameObject targetRoom = spawnedRooms[roomIndex].gameObject;
        LayoutSpawner layout = GetLayoutSpawner(targetRoom);
        Destroy(layout.gameObject);
        Instantiate(replacement, targetRoom.transform);
        spawnedRooms.Remove(targetRoom);
    }

    LayoutSpawner GetLayoutSpawner(GameObject room)
    {
        foreach (Transform child in room.transform)
        {
            if (child.name == "LayoutSpawner")
            {
                return child.GetComponent<LayoutSpawner>();
            }
        }
        return null;
    }

    void ClearAllChild(LayoutSpawner layout)
    {
        foreach(Transform child in layout.transform)
        {
            if (child.CompareTag("Enemy"))
            {
                layout.enemies.Remove(child.GetComponent<Enemy>());
            }
            Destroy(child.gameObject);
        }
    }
}
