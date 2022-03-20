using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolData : MonoBehaviour
{
	[SerializeField] private string Label;
	[SerializeField] private bool data;
	
	public bool GetData(){return data;}
	
	public void SetData(bool newData){
		data = newData;
	}
}
