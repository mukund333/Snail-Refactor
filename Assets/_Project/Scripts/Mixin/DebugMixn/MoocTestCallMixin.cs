using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoocTestCallMixin : MixinBase
{
	
	public MixinBase[] actionMixin;
	
	public bool	isTesting;
	
	

	
    
    void Start()
    {
        
    }

    
    void Update()
    {
		if(isTesting==true)
		{
			isTesting=false;
			actionMixin[0].CheckAndAction();
		}
    }
}
