using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score", menuName = "ScoreData")]
public class ScoreData : ScriptableObject
{
    [SerializeField] private int  score;
	
	public int Score
	{
		get{
			return score;
		}
		
		set{
			score = value;
		}
	}
}
