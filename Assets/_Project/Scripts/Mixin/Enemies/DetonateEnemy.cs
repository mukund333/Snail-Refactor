﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonateEnemy : AnimationBase
{
	[SerializeField] private IntData 		animStateIndex;
	[SerializeField] private MixinBase      callKillMixin;
	[SerializeField] private string 		animName;
	
	public override void Action()
	{
		StartCoroutine(PlayAndWaitForAnim(animName));
	}
	
	
	
	public IEnumerator PlayAndWaitForAnim(string stateName)
	{
		animStateIndex.SetData(2);
		
		//Wait until we enter the current state
		while (!animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
		{
			yield return null;
		}
		
		animator.speed = 0.5f;

		float waitTime = animator.GetCurrentAnimatorStateInfo(0).length;
		
		float counter = 0;
		while (counter < (waitTime))
		{
			counter += Time.deltaTime;
			Debug.Log("counter ");
			yield return null;
		}
		
		//Done playing. Do something below!
			callKillMixin.Action();
			
		yield break;
	}
}
