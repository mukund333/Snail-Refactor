using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementFromTarget : EnemyBase
{
	[SerializeField] private Vector3Data displacement;
	[SerializeField] private BoolData isCheckDisplacement;	

	private void Update()
	{
		if(isCheckDisplacement.GetData())
		{
			displacement.SetData(target.transform.position - transform.position);	
		}
		 
	}
}	
