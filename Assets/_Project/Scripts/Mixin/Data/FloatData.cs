using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatData : MonoBehaviour
{
	[SerializeField] private string Label;
	[SerializeField] private float data;
	
	public float GetData(){return data;}
	
	public void SetData(float newData){
		data = newData;
	}
	
	public void incrementData(float num)
	{
		data += num;
	}
   
   
}
