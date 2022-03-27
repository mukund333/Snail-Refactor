using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnemyData : MixinBase
{
	public EnemySpawnData[] enemies;
	
	
	
	
	private void Start()
	{
		for (int i = 0; i < enemies.Length; i++)
			{
				enemies[i].poolId = PoolManager.instance.GetPoolID(this.enemies[i].Name);

			}
	}
}
