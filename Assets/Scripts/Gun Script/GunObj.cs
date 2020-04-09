using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunObj : MonoBehaviour 
{
    public string gunName;
    public string ammoType;
    public int ammoClip;
    public GunObj(string name, string ammoName)
    {
        gunName = name;
        ammoType = ammoName;
    }

    public string GetGunName()
    {
        return gunName;
    }

    public string GetGunAmmo()
    {
        return ammoType;
    }
}
