using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCoolDown : MixinBase
{
	[SerializeField] private float cooldownTimer;
	
	private float cooldownTime;
	private bool  isCool = true;//default true
	
    public override bool Check()
	{
		return isCool;
	}
	
	public override void Action()
	{
		isCool = false;
		cooldownTime = 0.0f;
	}
	
	void Update()
	{
			if(!isCool)
			{
				cooldownTime += Time.deltaTime;
				if(cooldownTime > cooldownTimer)
				{
					isCool = true;
				}
			}
	}
}
