using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public List<string> weaponInventory;
    public List<Item> upgrades;
    public float attackMod;
    public float asMod;
    public bool wShot;
    public int level;
    public int score;
    public int lives;
}
