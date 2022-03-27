using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : EnemyBase
{
	[SerializeField] private FloatData  speed;
	[SerializeField] private bool  		isFollowing = true;
	[SerializeField] private Vector3Data displacementFromTarget;
	
	[Header("Movement Settings")]
					 private float 		angle = 90f; 
					 private Vector3 	directionToTarget;
					 private Vector3 	velocity;
					 				 
	public override bool Check()
	{
		return true;
	}
	
	public override void Action()
	{
			isFollowing = true;
	}
	
	private void Update()
	{
		if(isFollowing)
		{	
			
			directionToTarget = displacementFromTarget.GetData().normalized;
			velocity = directionToTarget * speed.GetData();
			transform.Translate(velocity * Time.deltaTime);
		}
	}
}
