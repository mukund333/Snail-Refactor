using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateFinisher : AnimationBase
{
	[SerializeField] private bool 		isAnimationFinish = false;
	[SerializeField] private StateData  stateData;
	[SerializeField] private IntData 	animStateIndex;
	[SerializeField] private int 		animIndex;
	[SerializeField] private string 	animName;
	//[SerializeField] private MixinBase 	callAnimationStateChanger;	
	
	
	
	
	//[SerializeField] private MixinBase 	callBehaviorStateChanger;		
	
	public override bool Check()
	{
		return !isAnimationFinish; 
	}
	
	
	
	public override void Action()
	{
		isAnimationFinish = false;
		//Debug.Log("Anim finish action");
		StartCoroutine(PlayAndWaitForAnim(animName));

	}
	
	
	public IEnumerator PlayAndWaitForAnim(string stateName)
	{
		
		animator.speed = 0.5f;
		animStateIndex.SetData(animIndex);
		
		
		//Wait until we enter the current state
		while (!animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
		{
			yield return null;
			Debug.Log("PlayAndWaitForAnim");
		}

		float counter = 0;
		float waitTime = animator.GetCurrentAnimatorStateInfo(0).length;

		//Now, Wait until the current state is done playing
		while (counter < (waitTime))
		{
			counter += Time.deltaTime;
			yield return null;
		}
		
		//Done playing. Do something below!
		stateData.SetStateData(State.Aiming);
		Debug.Log( isAnimationFinish);
			animator.speed = 1f;
		isAnimationFinish = true;
	
		Debug.Log(isAnimationFinish);
		yield break;
	}
}
