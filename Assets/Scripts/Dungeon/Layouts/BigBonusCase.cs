using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBonusCase : MonoBehaviour
{
    public WeaponManager wManager;
    // Start is called before the first frame update
    void Start()
    {
        wManager = GameObject.Find("WeaponManager").GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
