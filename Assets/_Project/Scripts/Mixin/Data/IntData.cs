using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntData : MonoBehaviour
{
	
	[SerializeField] private string Label;
	[SerializeField] private int 	data;
	public int GetData(){return data;}
	
	public void SetData(int newData){
		data = newData;
	}
	
	public void incrementData(int num)
	{
		data += num;
	}
	
}
