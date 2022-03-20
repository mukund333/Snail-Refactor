using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : AnimationBase
{
	[SerializeField] private IntData 		animStateIndex;
	[SerializeField] private int 			previousAnimStateIndex;
	[SerializeField] private bool		 	isAnimStateChanged 		= true;
	
	public override bool Check()
	{
		return isAnimStateChanged;
	}
    
	
	
	public override void Action()
	{
		ChangeAnimationState(animStateIndex.GetData());
	}
	
	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
	
	void Start()
	{
		previousAnimStateIndex = 0;
		animStateIndex.SetData(0);
	}
	
	void Update()
	{
		if(previousAnimStateIndex !=animStateIndex.GetData())
		{
			Action();
			previousAnimStateIndex = animStateIndex.GetData(); 
		}
	}
}
