using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutSpawner: MonoBehaviour
{
    public LayoutTempProvider layoutTemps;
    public List<Enemy> enemies = new List<Enemy>();
    public bool caseSpawned;
    private PlayerController player;
    private GameObject Door;
    public bool spawnDoorOnce;
    void Start()
    {
        layoutTemps = GameObject.Find("LayoutTempProvider").GetComponent<LayoutTempProvider>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnRandomWeeds();
        SpawnRandomEnemies();
    }

    private void Update()
    {
        if (enemies.Count == 0 && !caseSpawned)
        {
            Instantiate(layoutTemps.smallBonusCase, new Vector3(-3, -3, 0) + transform.parent.transform.position, Quaternion.identity, transform);
            Destroy(Door);
            caseSpawned = true;
        }
        if (!spawnDoorOnce && (player.transform.position - transform.position).magnitude <= 4.4f)
        {
            Door.SetActive(true);
            spawnDoorOnce = true;
        }
    }

    private void SpawnRandomEnemies()
    {
        int randomNum = Random.Range(3, 6);
        for(int i = 0; i < randomNum; i++)
        {
            int randomTemp = Random.Range(0, layoutTemps.enemyTemps.Length);
            Enemy enemy = Instantiate(layoutTemps.enemyTemps[randomTemp], transform.parent.transform.position + RandomPos(), Quaternion.identity, transform.parent.transform);
            enemy.transform.SetParent(transform);
            enemy.layout = gameObject.GetComponent<LayoutSpawner>();
            enemies.Add(enemy);
        }

    }

    private void SpawnRandomWeeds()
    {
        int randomTemp = Random.Range(0, layoutTemps.weedsTemps.Length);
        GameObject layout = Instantiate(layoutTemps.weedsTemps[randomTemp], transform.parent.transform);
        layout.transform.SetParent(transform);
        Door = Instantiate(layoutTemps.Door, transform.parent.transform);
        Door.SetActive(false);
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f), 0);
    }
}
