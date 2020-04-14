using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletPattern", menuName = "BulletPattern")]
//Scriptable Object to create different kinds of pattern templates.
public class BulletPatterns : ScriptableObject
{
   public string patternName;
   public bool burstFire;
   public float angleOne;
   public float angleTwo;
   public float burstFireDelay;
   public int numShots;
   public int burstAmount;
}
