using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletPattern", menuName = "BulletPattern")]
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
