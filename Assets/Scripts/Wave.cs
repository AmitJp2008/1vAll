using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Gameplay/Wave Data")]
public class Wave : ScriptableObject
{
    [SerializeField] private int amountOfStartingEnemies;
    [SerializeField] private int amountOfIncreasedEnemiesPerWave;
    [SerializeField] private float delayBetweenWaves = 2f;
    [SerializeField, Tooltip("in percentage")] private float healthIncrementAmount;
    [SerializeField, Tooltip("in percentage")] private float attackPowerIncrementAmount;

    public int StartingEnemies => amountOfStartingEnemies;
    public int AmountOfIncreasedEnemiesPerWave => amountOfIncreasedEnemiesPerWave;
    public float HealthIncrementAmount => healthIncrementAmount;
    public float AttackPowerIncrementAmount => attackPowerIncrementAmount;
    public float DelayBetweenWaves => delayBetweenWaves;
}
