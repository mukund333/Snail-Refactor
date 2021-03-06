using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorStateChanger : MixinBase
{
	
	[SerializeField] private StateData  	stateData;
	[SerializeField] private IntData 		animStateIndex;
	[SerializeField] private BoolData 		isImmortal;
	[SerializeField] private bool		 	isChangeInState 		= true;
	[SerializeField] private MixinBase[]	callSubMixins;
	
	

	public override bool Check()
	{
		return isChangeInState;
	}
	
	
	
	
	public override void Action()
	{
		isChangeInState = true;
		
		ChangeBehaviorState(stateData.GetStateData());

	}
	
	
	
	void ChangeBehaviorState(State newState){
		
		switch (newState)
		{
			case State.Moving:
					isImmortal.SetData(false);
					callSubMixins[0].CheckAndAction();
					//Debug.Log("Moving state");
				break;
			
			case State.Busy:
				break;		
			
			case State.Aiming:
					isImmortal.SetData(true);
					//Debug.Log("aim state");
					animStateIndex.SetData(2);
					callSubMixins[1].CheckAndAction();
				break;
			
			
			
			case State.Charging:
					isImmortal.SetData(true);
					//Debug.Log("Charging state");
					animStateIndex.SetData(3);
					
				break;
				
		}
	}
}
