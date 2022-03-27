using System;
using UnityEngine;

[Serializable]
public struct EnemySpawnData 
{
		public string Name;

		public int spawnStartTime;

		public Vector2 spawnFreqRange;

		public int timeToMaxSpawnFreq;

		public AnimationCurve curve;
		
		public float debug;
		
		public int poolId;
}
