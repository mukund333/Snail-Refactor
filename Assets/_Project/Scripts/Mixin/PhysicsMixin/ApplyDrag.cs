using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDrag : MixinBase
{
	[Space]
	[Header("DragCurve Settings")]
	[SerializeField] private float 			 accDrag;
	[SerializeField] private float 			 accTimeDrag;
	[SerializeField] private AnimationCurve  accCurveDrag;
	
	
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private bool 			 isApplyingDrag = false;
	[SerializeField] private float 		  	 weaponDrag;
	
	
	private void Awake()
	{
		rb2d = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
	}
	
	public override bool Check()
	{
		return !isApplyingDrag;
	}
	
	public override void Action()
	{
		isApplyingDrag = true;	
	}
	
	private void FixedUpdate()
    {
		if(isApplyingDrag == true)
		{
				isApplyingDrag = false;
			
			accDrag = accDrag + 1f / accTimeDrag * Time.deltaTime;
			rb2d.drag = weaponDrag * accCurveDrag.Evaluate(accDrag);
			accDrag = Mathf.Clamp(accDrag, 0f, 1f);
		}
	}
}
