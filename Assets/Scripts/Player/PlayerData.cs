using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public List<string> weaponInventory;
    public List<string> upgrades;
    public int level;
    public int score;
    public int lives;
}
