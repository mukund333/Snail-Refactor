using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : EnemyBase
{
	[SerializeField] private Vector3Data 	displacement;
	[SerializeField] private BoolData  		isCheckDisplacement;	
	
	[SerializeField] private StateData  	stateData;
	[SerializeField] private BoolData  		isAiming;	
	[SerializeField] private float 			chargeSpeed	 			= 20f;
	
	
    void Update()
	{
		switch (stateData.GetStateData())
		{
			case State.Charging:
					
					float chargeSpeedUpMultiplier = 1f;
					chargeSpeed += chargeSpeed * chargeSpeedUpMultiplier * Time.deltaTime;
					
				break;
		}
	}
	
	private void FixedUpdate()
	{
		switch (stateData.GetStateData())
		{
			case State.Charging:
					isCheckDisplacement.SetData(false);
					isAiming.SetData(false);
					rb2d.AddForce(displacement.GetData() * chargeSpeed);
					
				break;
		}

	}
}
