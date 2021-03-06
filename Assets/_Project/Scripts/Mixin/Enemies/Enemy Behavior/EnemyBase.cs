using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MixinBase
{
	[SerializeField] protected Rigidbody2D rb2d;
	[SerializeField] protected Transform target;
	[SerializeField] protected Transform enemySprite;

	
	protected virtual void OnEnable()
	{
		rb2d 		 = 	GetComponent<Rigidbody2D>();
		target 		 = 	GameObject.Find("Snail").transform;
		
	}
	
	protected virtual void Start()
	{
		enemySprite =  gameObject.transform.GetChild(0);
	}


}
