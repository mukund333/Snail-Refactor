using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MixinBase
{
	public int currentWeaponIndex = 0;	
    [SerializeField] private List<CallMixinActions> weaponList = new List<CallMixinActions>();
	
	
	
	public override void Action()
	{
		weaponList[currentWeaponIndex].CheckAndAction();	
	}
}
