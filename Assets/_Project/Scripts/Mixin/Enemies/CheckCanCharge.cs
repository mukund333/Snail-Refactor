using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanCharge : EnemyBase
{	
	
	[SerializeField] private FloatData 		targetDistance;
	[SerializeField] private Vector3Data 	directionToTarget;
	[SerializeField] private LayerMask 		layerMask;
	[SerializeField] private bool			canCharge		= false;
	
	
	public override bool Check()
	{
		return canCharge;
	}
	
	public override void Action()
	{
		canCharge = false;
	}
		

	private void Update()
	{
		if(canCharge == false)
		{
			Vector3 dirToTarget	= directionToTarget.GetData().normalized;
			RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, dirToTarget, targetDistance.GetData(), layerMask);
			
		
			if(raycastHit2D.collider == null )
			{
				canCharge = false;
				Debug.Log("target null");	
			}else if(raycastHit2D.collider.gameObject == target.gameObject)
			{
				canCharge = true;
				Debug.Log("Got the player");
			}	
		} 
	}
}
