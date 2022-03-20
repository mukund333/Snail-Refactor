using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToChargeState : MixinBase
{
   [SerializeField] private StateData  	stateData;
   
   public override bool Check()
	{
		return true;
	}
	
	public override void Action()
	{
		
		stateData.SetStateData(State.Charging);
	}
}
