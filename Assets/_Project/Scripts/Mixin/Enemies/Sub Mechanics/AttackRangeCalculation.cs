using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCalculation : MixinBase
{
	[SerializeField] private FloatData 		distance;
	[SerializeField] private FloatData 		speed;
	[SerializeField] private float 			attackRange;	
	
	[SerializeField] private MixinBase		animationStateFinisher; 
	[SerializeField] private bool			isAttackRange = false;
	
	public override bool Check()
	{	
		return !isAttackRange;
	}
	
    public override void Action()
	{
		isAttackRange = false;
	}
	
	void Update()
	{
		if(distance.GetData() <= attackRange)
		{
			speed.SetData(0f);
			isAttackRange = true;
			//Debug.Log(isAttackRange);
		}		
		
		
		 if(isAttackRange)
		 {
			 if(animationStateFinisher.Check())
			 {
				 Debug.Log("Attack Range ");
				animationStateFinisher.Action();	
			 }
			 isAttackRange = false;
		}
	}
	
	
}
