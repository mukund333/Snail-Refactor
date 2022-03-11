using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRigidbody : MixinBase
{
	public Rigidbody2D  	 rb2d;
	
	private void Awake()
	{
		rb2d = gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
	}
	
	
	
	
}
