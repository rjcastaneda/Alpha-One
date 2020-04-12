using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletPattern", menuName = "BulletPattern")]
public class BulletPatterns : ScriptableObject
{
   public string patternName;
   public bool aimPlayer;
   public bool rotation;
   public float angleOne;
   public float angleTwo;
   public float stepAngle;
    public float rotAngleStart;
   public float rotAngleEnd;
   public float interval;
   public int fireSpeed;
   public int numBulletStreams;
   public int numShots;
}
