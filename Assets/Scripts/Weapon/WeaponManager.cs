using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weaponList = new List<Weapon>();
    public List<Weapon> equippedWeapon = new List<Weapon>();
    private int curIndex = 1;
    public PlayerController player;
    public GameObject weaponHolder;

    void Start()
    {
        equippedWeapon[0] = weaponList[0];
        equippedWeapon[1] = weaponList[1];
        weaponHolder = GameObject.Find("WeaponHolder");
        SwitchWeapon();
        
    }
    public void SwitchWeapon()
    {
        curIndex = (curIndex + 1) % 2;
        if (player.curWeapon)
        {
            Destroy(GameObject.Find(player.curWeapon.name));
        }
        player.curWeapon = Instantiate(equippedWeapon[curIndex], weaponHolder.transform.position, Quaternion.identity, weaponHolder.transform);
        player.curWeapon.isKept = true;
        player.curWeapon.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void AddWeapon(Weapon weapon)
    {
        Weapon replace = Instantiate(player.curWeapon, weapon.transform.position, Quaternion.identity);
        replace.isKept = false;
        replace.GetComponent<BoxCollider2D>().enabled = true;
        // add weapon to equipped weapon list
        equippedWeapon[curIndex] = weaponList[weapon.id];
        curIndex = (curIndex + 1) % 2;

        SwitchWeapon();
    }

    public Weapon GetRandomWeapon()
    {
        int rand = Random.Range(2, weaponList.Count);
        return weaponList[rand];
    }

}
