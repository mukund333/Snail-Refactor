using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAimTarget : EnemyBase
{
	[SerializeField] private BoolData isAim;
	
	public override bool Check()
	{
		return isAim.GetData();
	}
	public override void Action()
	{
		isAim.SetData (true);
		
	}
	
	private void Update()
	{
		if(isAim.GetData()==true)
		{
			AimTarget(target.transform.position);	
		}
		
	}
	
	
	public void AimTarget(Vector3 targetPosition){
		Vector3 aimDir = (targetPosition - transform.position).normalized;
		turtleSprite.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(aimDir));
	}
	
	public static float GetAngleFromVectorFloat(Vector3 dir){
		dir = dir.normalized;
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if (n < 0) n += 360;

		return n;
	}
}
