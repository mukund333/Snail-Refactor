using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePhysics : MixinBase
{
	
	[SerializeField] private float 			 accThrust;
	[SerializeField] private float 			 accTimeThrust;
	[SerializeField] private AnimationCurve  accCurveThrust;
	
	[SerializeField] private float 		  	 weaponThrust;
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private bool 			 isApplyingCurve = false;
	
	
	private void Awake()
	{
		rb2d = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
	}
	
	public override bool Check()
	{
		return !isApplyingCurve;
	}
	
	public override void Action()
	{
		isApplyingCurve = true;	
	}
	
    private void FixedUpdate()
    {
			if(isApplyingCurve== true)
			{
				isApplyingCurve=false;
				
				accThrust = accThrust + 1f / accTimeThrust * Time.deltaTime;
				rb2d.velocity = transform.right * (weaponThrust * accCurveThrust.Evaluate(accThrust));
				accThrust = Mathf.Clamp(accThrust, 0f, 1f);
        
				if (accThrust > 0f)
				{
					accThrust = this.rb2d.velocity.magnitude / weaponThrust;
				}	
			}
    }
	
}
