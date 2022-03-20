using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorState : MixinBase
{
	[SerializeField] private MixinBase actionMixin;
   
	public override bool Check()
	{
		return true;
	}
	
	
	public override void Action()
	{
		
	}
   
    void Update()
	{
		if(actionMixin.Check())
		{
			Debug.Log(actionMixin.Check());
			actionMixin.Action();
		}
	}
}
