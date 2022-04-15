using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDatabase : MonoBehaviour
{
	[SerializeField] private IntData 		scoreData;
	[SerializeField] private ScoreData  	storeScoreData; 
    
   
	private void OnEnable()
	{
		KillEnemy.OnEnemyDeadth += AddScore;	
	}
	
	private void OnDisable()
	{
		KillEnemy.OnEnemyDeadth -= AddScore;
	}
   
	private void Awake()
	{
		SetScoreData();	
	}

	public int GetScoreData()
	{
		return storeScoreData.Score;
	}
	
	public void SetScoreData()
	{
		scoreData.SetData(storeScoreData.Score);
	}
	
	private void AddScore()
	{
		storeScoreData.Score++;
	}
	
}
