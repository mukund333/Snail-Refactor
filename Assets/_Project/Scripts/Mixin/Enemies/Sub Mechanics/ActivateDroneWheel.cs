using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDroneWheel : MixinBase
{
	[SerializeField]    private GameObject firstWheel;
	[SerializeField]	private GameObject secondWheel;
	[SerializeField]	private GameObject thirdWheel;
	
	void OnEnable()
	{
			firstWheel = this.gameObject.transform.GetChild(1).gameObject;
			secondWheel = this.gameObject.transform.GetChild(2).gameObject;
			thirdWheel = this.gameObject.transform.GetChild(3).gameObject;
			firstWheel.SetActive(true);
			secondWheel.SetActive(true);
			thirdWheel.SetActive(true);
	}
}
