using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDelay : MixinBase
{
	[SerializeField] private bool 		isChargeDelayFinish = true;
	[SerializeField] private StateData  stateData;
	[SerializeField] private float 		delay;
	
	public override bool Check()
	{
		return isChargeDelayFinish;
	}
	
	public override void Action()
	{
		isChargeDelayFinish = true;
		StartCoroutine(ChargeTimer());
	}
	
	public IEnumerator ChargeTimer()
	{
		 yield return new WaitForSeconds(delay);
		 isChargeDelayFinish = false;
		 stateData.SetStateData(State.Charging);
		
		yield break;	

	}
}
