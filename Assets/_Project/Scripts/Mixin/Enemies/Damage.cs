using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MixinActionable
{
	
	[SerializeField] private IntData currentHealth;
	
	
	
	[SerializeField] private int damageAmount;
	
	public override bool Check()
	{
		if(currentHealth.GetData() <= 0)
		{
			return false;
		}
		
		return true;
	}
	
	public override void Action()
	{
		GetDamage(damageAmount);
	}
	
	public void GetDamage(int dmg)
	{
		currentHealth.incrementData(-dmg);
		
		//Call HitImmobalize mixin
		actionableMixin[1].Action();
		
		if(currentHealth.GetData() <= 0)
		{	
			//Call Kill mixin
			actionableMixin[0].Action();
		}else
		{
			//Call SpriteFlash mixin
			actionableMixin[2].Action();
		}
		
	}
}
