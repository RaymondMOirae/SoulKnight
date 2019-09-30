using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weaponList = new List<Weapon>();
    public List<Weapon> equippedWeapon = new List<Weapon>();
    public PlayerController player;

    public void Innitialize()
    {
        equippedWeapon[1] = weaponList[1];
    }
    public void SwitchWeapon()
    {
        if(player.curWeapon = equippedWeapon[0])
        {
            player.curWeapon = equippedWeapon[1];
        }
        else
        {
            player.curWeapon = equippedWeapon[0];
        } 
    }
}
