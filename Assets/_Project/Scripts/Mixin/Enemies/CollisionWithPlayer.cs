using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MixinActionable
{
	private bool isCollid;
	
	public override bool Check()
	{
		return  !isCollid;
	}
	
	public override void Action()
	{
		
		isCollid = false;
					

	}
	
   private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.CompareTag("Player"))
		{		
					isCollid = true;		
					Debug.Log("collide to player");
					actionableMixin[0].Action();
		}
	} 
}
