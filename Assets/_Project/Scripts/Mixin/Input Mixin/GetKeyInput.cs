using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyInput : InputBase
{
	[SerializeField] private ShootTouch		 shootTouch;
	
	private void Start()
	{
		shootTouch 			= 	FindObjectOfType<ShootTouch>();
	}
	
	void Update()
	{
		if (Input.GetKey(KeyCode.S) || shootTouch.IsDown())
		{
			actionMixin.CheckAndAction();
		}
	}
		
}
