using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MixinBase
{
    [SerializeField] private FloatData 		distance;
	[SerializeField] private IntData 		animStateIndex;
	
	[SerializeField] private float detonateRange;
	[SerializeField] private bool isDetonating = false;
	
	private void OnEnable()
	{
		animStateIndex.SetData(0);
		isDetonating = false;
	}
	
	public override bool Check()
	{
			return !isDetonating;
	}	
	
	public override void Action()
	{
		isDetonating = false;
		
		Debug.Log(" detect player");
	}
	
	void Update()
	{
			if(isDetonating == false)
			{
				if (distance.GetData() <= detonateRange){
					isDetonating = true;
					animStateIndex.SetData(1);
					Debug.Log(" detect player");
				}
			}
		
	}
}
