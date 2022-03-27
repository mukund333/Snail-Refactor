using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorStateChangeChecker : MixinBase
{
	[SerializeField] private StateData  	newStateData;
	[SerializeField] private State  		previousStateData;
	[SerializeField] private bool		 	isStateChanged = true;
	[SerializeField] private MixinBase 		callBehaviorStateChanger;
	
	
	public override bool Check()
	{
		return isStateChanged;
	}
    
	
	public override void Action()
	{		
			isStateChanged = false;
			
			callBehaviorStateChanger.CheckAndAction();
	}
	
	
    void Start()
    {
		previousStateData 	= State.Busy;
		newStateData.SetStateData(State.Moving);
    }
	
    void Update()
    {
		
        if(previousStateData != newStateData.GetStateData())
		{
			isStateChanged = true;
			//Debug.Log(isStateChanged);
			previousStateData = newStateData.GetStateData();
			
		}
    }
}
