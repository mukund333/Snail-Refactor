using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBehavior : MixinBase
{
    [SerializeField] private MixinBase CallEagle;
	
    void Start()
    {
        CallEagle.CheckAndAction();
    }

   
}
