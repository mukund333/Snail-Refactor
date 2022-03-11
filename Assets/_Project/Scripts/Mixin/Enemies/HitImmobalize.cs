using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitImmobalize : MixinBase
{
	private WaitForEndOfFrame waitForFrame = new WaitForEndOfFrame();
	
	
	
	public override void Action()
	{
		StartCoroutine(Hit());
	}
	
	public IEnumerator Hit()
	{
		float time = 0.1f;
		float timer = 0f;
		Vector3 pos = transform.position;
		while (timer < time)
		{
			timer += Time.deltaTime;
			yield return waitForFrame;
			transform.position = pos;
		}
		yield break;
	}
}
