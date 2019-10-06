using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBonusCase : MonoBehaviour
{
    public WeaponManager wManager;
    public bool opened;
    // Start is called before the first frame update
    void Start()
    {
        wManager = GameObject.Find("WeaponManager").GetComponent<WeaponManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !opened)
        {
            // generate random position
            Vector2 randomPoint = Random.insideUnitCircle.normalized;
            Vector3 randomPos = new Vector3(randomPoint.x, randomPoint.y, 0.0f);

            // choose a random gun from weapon prefabs
            Weapon randWeapon = Instantiate(wManager.GetRandomWeapon(), transform.position + randomPos, Quaternion.identity);
            opened = true;
        }
    }


}
