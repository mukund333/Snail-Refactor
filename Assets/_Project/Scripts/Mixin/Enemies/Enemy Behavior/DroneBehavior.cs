using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehavior : MonoBehaviour
{
	[SerializeField] private MixinBase CallDrone;
	
    void OnEnable()
    {
        CallDrone.CheckAndAction();
    }
}
