using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MixinBase
{
	protected Rigidbody2D rb2d;
	protected Transform target;
	
	protected virtual void OnEnable()
	{
		rb2d 	= 	GetComponent<Rigidbody2D>();
		target 	= 	GameObject.Find("Snail").transform;
	}


}
