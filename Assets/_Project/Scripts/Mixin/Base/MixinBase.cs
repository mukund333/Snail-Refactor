using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixinBase : MonoBehaviour
{
		// Check is called once 
		public virtual bool Check()
		{
			return true;
		}
	
		// Action is called once 
		public virtual void Action()
		{
			
		}
		
		public void CheckAndAction()
		{
			if(Check())
			{
				Action();
			}
		}
}
