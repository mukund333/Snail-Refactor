using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculation : EnemyBase
{
	[SerializeField] private FloatData distance;
	[SerializeField] private bool isCalcDistance = true;

	public override bool Check()
	{
			return isCalcDistance;
	}	
	
	public override void Action()
	{
		isCalcDistance = true;
	}
	
	
	private void Update()
	{
		if(isCalcDistance == false)
			return;
		
		if (target == null)
			return;
		
		distance.SetData(Vector3.Distance(target.position, transform.position));
		
	}
}
