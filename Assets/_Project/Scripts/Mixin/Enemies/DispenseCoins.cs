using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseCoins : EnemyBase
{
	[SerializeField] private Vector2 		coinAmount;
	[SerializeField] private int 			coinID;
	
	
	void Start()
	{
		coinID = PoolManager.instance.GetPoolID("Coin");
	}
	
	
    public override void Action()
	{
		int num = (int)UnityEngine.Random.Range(this.coinAmount.x, this.coinAmount.y);
			
		for (int i = 0; i < num; i++)
		{
				PoolManager.instance.GetObject(this.coinID, base.transform.position, Quaternion.identity);
		}
	}
}
