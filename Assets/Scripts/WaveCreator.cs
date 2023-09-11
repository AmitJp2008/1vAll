using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class WaveCreator : MonoBehaviour
{
    [SerializeField] private Wave waveData;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private EnemyData[] possibleEnemies;

    private bool gameStarted = false;
    private int waveCounter = 0;
    private int currentAmountOfEnemies = 0;
    private void OnEnable()
    {
        GameplayEvents.Instance.EnemyDied += EndWave;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.EnemyDied -= EndWave;
    }

    private void Start()
    {
        //Testing
        CreateWave();
    }

    private void CreateWave()
    {
        if (!gameStarted)
        {
            StartWave();
        }
        else 
        {
            StartNewWave();
        }
        waveCounter++;
    }

    private void StartNewWave() 
    {
        StartCoroutine(StartNewWaveSequence());
    }

    private IEnumerator StartNewWaveSequence() 
    {
        yield return StartCoroutine(WaitUntilNewWaveStarts());
        StartWave();
    }

    private IEnumerator WaitUntilNewWaveStarts() 
    {
        yield return new WaitForSeconds(waveData.DelayBetweenWaves);
    }

    private void StartWave() 
    {
        if (waveData == null) return;

        gameStarted = true;
        int currentEnemyIndex = 0;
        currentAmountOfEnemies = waveData.StartingEnemies + (waveCounter * waveData.AmountOfIncreasedEnemiesPerWave);
         
        while (currentEnemyIndex < currentAmountOfEnemies)
        {
            int rand = Random.Range(0, possibleEnemies.Length);
            var enemyBase = spawner.SpawnEnemy(possibleEnemies[rand].EnemyPrefab);
            SetWaveEnemy(enemyBase, possibleEnemies[rand]);
            currentEnemyIndex++;
        }

        GameplayEvents.Instance.WaveCreated?.Invoke(currentAmountOfEnemies);
    }

    private void SetWaveEnemy(EnemyBase enemy, EnemyData enemyData) 
    {
        enemy.SetEnemyHealth(enemyData.Health + (enemyData.Health * waveData.HealthIncrementAmount));
        enemy.SetEnemyDamage(enemyData.Damage + (enemyData.Damage * waveData.AttackPowerIncrementAmount));
    }

    private void EndWave(EnemyBase _) 
    {
        currentAmountOfEnemies--;
        if (currentAmountOfEnemies == 0)
        {
            CreateWave();
        }
    }
}   
