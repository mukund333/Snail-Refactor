using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMechanics : EnemyBase
{
	[SerializeField] private float 			Speed;
	[SerializeField] private float 			turnRate;
	
	
	
	
	protected override void OnEnable()
	{
		base.OnEnable();
		StartCoroutine(Behave());
		

	}
	
	
	private IEnumerator Behave()
	{
		
		while (gameObject.activeInHierarchy)
		{
			if (!target)
			{
		
				break;
			}
		
			Vector2 dir = target.position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * 57.29578f;
			Quaternion rot = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.fixedDeltaTime * this.turnRate);
			rb2d.velocity = transform.right * Speed;
			yield return 0;
		}
		yield return 0;
		yield break;
	}
}
