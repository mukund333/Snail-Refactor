using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyThrust : MixinBase
{
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private float 		  	 weaponThrust;
	[SerializeField] private float 		  	 weaponDrag;
	[SerializeField] private bool 			 isApplyingThrust = false;

	
	private void Awake()
	{
		rb2d = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
	}
	
	
	
	
	
	
	public override bool Check()
	{
		return !isApplyingThrust;
	}
	
	public override void Action()
	{
		isApplyingThrust = true;	
	}
	
    private void FixedUpdate()
    {
		if(isApplyingThrust== true)
		{
			rb2d.AddForce(transform.right * weaponThrust, ForceMode2D.Impulse);
			isApplyingThrust=false;
		}
	}
		
}
