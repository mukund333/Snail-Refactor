using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRecoil : MixinBase
{
    [SerializeField] private bool  			 isRecoilFinish = true;  			//default true
	[SerializeField] private Rigidbody2D  	 rb2d;
	
	private void Awake()
	{
		rb2d = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
	}
	
	public override bool Check()
	{
		return isRecoilFinish;
	}
	
	public override void Action()
	{
		isRecoilFinish = false;
		
	}
	
	void Update()
	{
			if(!isRecoilFinish)
			{
					
				if(VelocityMagnitude() == 0){
					
					isRecoilFinish = true;
				}
			}

	
	}
							
	
	
	
	private int VelocityMagnitude()
    {
		return (int) rb2d.velocity.magnitude;
        
    }
	
	
}
