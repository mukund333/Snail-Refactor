using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : MixinBase
{
	[SerializeField] private int defaultWeaponIndex = 0;
	[SerializeField] private WeaponSwitching 	weaponIndexer;
	
	
	
	[SerializeField] private float 		switchTimer = 2f;
	[SerializeField] private float   	switchTime;	 
	
	
	
	void Update()
	{
			if(defaultWeaponIndex == weaponIndexer.currentWeaponIndex)
			{
				return;
				
			}else{
				
				switchTime += Time.deltaTime;
				
				if(switchTime>switchTimer)
				{
						weaponIndexer.currentWeaponIndex = defaultWeaponIndex;
						switchTime = 0f;
				}
			}
	}
	
	
	
}
