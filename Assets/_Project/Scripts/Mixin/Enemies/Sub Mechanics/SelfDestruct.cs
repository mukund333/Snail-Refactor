using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MixinBase
{
	
	[SerializeField] private float	  		selfDestructTimer;
					 private float   		selfDestructTime;
	[SerializeField] private bool 			isSelfDestructing = true;
		
	public override bool Check()
	{
		return  isSelfDestructing;
		
	}
	
	public override void Action()
	{
		isSelfDestructing = true;
	}
	
	private void Update()
	{		

		if(isSelfDestructing)
		{
			selfDestructTime += Time.deltaTime;
				
			if(selfDestructTime>selfDestructTimer)
			{
				selfDestructTime = 0f;
				gameObject.SetActive(false);//Kill() hide becuse of coins			
			}
		}
	}
	
}
