using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : EnemyBase
{
	[SerializeField] private InitEnemyData enemiesData;
	[SerializeField] private float timer;
	[SerializeField] private bool stopSpawn = false;
	[SerializeField] private float spawnRadius = 300f;
	
	private void Start()
	{
		StartSpawning();
	}
	
    private void StartSpawning(){
				
			stopSpawn = false;
			for (int i = 0; i < enemiesData.enemies.Length; i++)
			{
				StartCoroutine(SpawnEnemy(enemiesData.enemies[i]));
			}
			StartCoroutine(Timer());
	}
	
	private IEnumerator SpawnEnemy(EnemySpawnData enemy){
			float startedTime = timer;
			float startFrequency = enemy.spawnFreqRange.x;
			float spawnFrequency = 0f;
			while (!stopSpawn && timer < enemy.spawnStartTime)
			{
				yield return 0;
			}
			while (!this.stopSpawn)
			{
				PoolManager.instance.GetObject(enemy.poolId, (Vector2)target.position + UnityEngine.Random.insideUnitCircle.normalized * spawnRadius, Quaternion.identity);
				spawnFrequency = Mathf.Lerp(startFrequency, enemy.spawnFreqRange.y, enemy.curve.Evaluate(Mathf.Lerp(0f, 1f, (this.timer - startedTime) / (float)enemy.timeToMaxSpawnFreq)));
				//MonoBehaviour.print(spawnFrequency);
				yield return new WaitForSeconds(1f / spawnFrequency);
			}
			yield break;
		}

	private IEnumerator Timer(){
			timer = 0f;
			while (!stopSpawn)
			{
				timer += Time.deltaTime;
				yield return 0;
			}
			timer = 0f;
			yield break;
		}
}
