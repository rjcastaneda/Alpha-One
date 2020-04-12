using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour 
{
    public string wepName;
    public string ammoType;
    public float FireSpeed;
    public WeaponObj(string name, string ammoName)
    {
        wepName = name;
        ammoType = ammoName;
    }

    public string GetGunName()
    {
        return wepName;
    }

    public string GetGunAmmo()
    {
        return ammoType;
    }
}
