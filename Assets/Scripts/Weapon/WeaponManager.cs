using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weaponList = new List<Weapon>();
    public List<Weapon> equippedWeapon = new List<Weapon>();
    private int curIndex = 0;
    public PlayerController player;
    public GameObject weaponHolder;

    void Start()
    {
        equippedWeapon[0] = weaponList[0];
        equippedWeapon[1] = weaponList[1];
        weaponHolder = GameObject.Find("WeaponHolder");
        player.curWeapon = Instantiate(equippedWeapon[0], weaponHolder.transform.position, Quaternion.identity);
        player.curWeapon.transform.SetParent(weaponHolder.transform);
    }
    public void SwitchWeapon()
    {
        if(curIndex == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
            player.curWeapon = Instantiate(equippedWeapon[1], weaponHolder.transform.position, Quaternion.identity);
            player.curWeapon.transform.SetParent(player.transform.GetChild(1));
            curIndex = 1;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Knife"));
            player.curWeapon = Instantiate(equippedWeapon[0], weaponHolder.transform.position, Quaternion.identity);
            player.curWeapon.transform.SetParent(player.transform.GetChild(1));
            curIndex = 0;
        } 
    }
}
