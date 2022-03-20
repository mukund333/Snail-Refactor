using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedChanger : AnimationBase
{
	[SerializeField] private FloatData 	animtorSpeed;
	
   	public override void Action()
	{
		ChangeAnimationState(animtorSpeed.GetData());
	}
	
	void ChangeAnimationState(float value){
		animator.speed = value;
	}
}
