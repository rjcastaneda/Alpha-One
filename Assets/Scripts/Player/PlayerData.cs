using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public int level;
    public int lives;
    public List<string> weaponInventory;
    public List<string> upgrades;
}
