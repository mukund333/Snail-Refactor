using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MixinBase
{
    [SerializeField] private FloatData 		distance;
	[SerializeField] private IntData 		animStateIndex;
	
	[SerializeField] private float detonateRange;
	[SerializeField] private bool isDetonating = false;
	
	
	public override bool Check()
	{
			return isDetonating;
	}	
	
	public override void Action()
	{
		isDetonating = false;
	}
	
	void Update()
	{
		
			if (distance.GetData() <= detonateRange){
				isDetonating = true;
				animStateIndex.SetData(1);
				Debug.Log(" detect player");
			}else if(animStateIndex.GetData()!=2)
			{
				animStateIndex.SetData(0);
			}
		
	}
}
