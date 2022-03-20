using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MixinActionable
{
	[SerializeField] private IntData currentHealth;
	[Range(0, 10)]
	[SerializeField] private int BaseHealth; 
	
	// bool isKilling;
	
	// public override bool Check()
	// {
		// isKilling = true;
		// return  !isKilling;
	// }
	
	public override void Action()
	{
		
		actionableMixin[0].Action();
		currentHealth.SetData(BaseHealth);
		gameObject.SetActive(false);
	}
}
