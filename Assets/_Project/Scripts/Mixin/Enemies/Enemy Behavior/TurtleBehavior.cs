using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehavior : MonoBehaviour
{
   [SerializeField] private MixinBase CallTurtle;
	
    void Start()
    {
        CallTurtle.CheckAndAction();
    }
}
