using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTake : MixinBase
{
   	[SerializeField] private IntData currentHealth;
						
	[SerializeField] private MixinBase CallKillEnemy;
	
	public int damageAmount;
	
	public override void Action()
	{
		
		
		
		
		
	}
	
	public void Damage(int damage)
	{
		
		currentHealth.incrementData(-damage);
		StartCoroutine(CheckHealth());
	}
	
	public IEnumerator CheckHealth()
	{
		yield return new WaitForSeconds(0.1f);
		
		if(currentHealth.GetData() <= 0 )
		{
				CallKillEnemy.Action();
		}
		
		yield break;
	}
	


}
