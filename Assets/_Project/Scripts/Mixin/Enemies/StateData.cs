using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateData : MonoBehaviour
{
	[SerializeField] private State state;
	
	public State GetStateData(){return state;}
	
	public void SetStateData(State newState){
		state = newState;
	}
}
