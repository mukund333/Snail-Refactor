using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillEnemy : MixinActionable
{
	
	public static event System.Action OnEnemyDeadth;// sub : 1.ScoreDatabase 2.update UI
	
	[SerializeField] private IntData currentHealth;
	//[SerializeField] private IntData score;
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
		
		OnEnemyDeadth?.Invoke();
		
		gameObject.SetActive(false);
		//score.incrementData(1);
	}
}
