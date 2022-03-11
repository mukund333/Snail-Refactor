using System;
using System.Collections;
using UnityEngine;


public class SpriteFlash : MixinBase
{

	[SerializeField] private SpriteRenderer renderer;
	
	public  void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		// if (!this.renderer)
		// {
			// this.renderer = base.GetComponentInChildren<SpriteRenderer>();
		// }
	}
	
	public override void Action()
	{
		StartCoroutine(SpriteFlashing());
	}


	public IEnumerator SpriteFlashing()
	{
		Debug.Log("SpriteFlash");
		float flashTime = 0.1f;
		float times = 2f;
		Material mat = this.renderer.material;
		int i = 0;
		while ((float)i < times)
		{
			if (!base.gameObject.activeInHierarchy)
			{
				break;
			}
			mat.SetFloat("_FlashAmount", 1f);
			yield return new WaitForSeconds(flashTime / 2f);
			if (!base.gameObject.activeInHierarchy)
			{
				break;
			}
			mat.SetFloat("_FlashAmount", 0f);
			yield return new WaitForSeconds(flashTime / 2f);
			i++;
		}
		yield break;
	}

	
	public void OnDisable()
	{
		try
		{
			Material material = this.renderer.material;
			material.SetFloat("_FlashAmount", 0f);
		}
		catch (Exception ex)
		{
			Debug.Log(ex);
		}
	}

	

}
