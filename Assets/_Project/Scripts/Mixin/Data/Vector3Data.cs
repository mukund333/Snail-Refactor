using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Data : MonoBehaviour
{
	[SerializeField] private Vector3 displacementData;
	
	public Vector3 GetData(){return displacementData;}
	
	public void SetData(Vector3 newDisplacementData){
		
		displacementData = newDisplacementData.normalized;
	}

}
