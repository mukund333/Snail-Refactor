using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBase : MixinBase
{
	[SerializeField] protected Animator animator;
	
	protected virtual void Awake()
	{
		animator = GetComponentInChildren<Animator>();
	}
}
