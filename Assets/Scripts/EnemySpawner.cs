using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform floor; // Reference to the floor
    [SerializeField] private float floorWidth;
    [SerializeField] private float floorLength;
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private float minDistanceFromPlayer; // Minimum distance from player
    [SerializeField] private GameObject debugEnemyObject;

    EnemySpawnPointGenerator enemySpawnPointGenerator;
    private List<Transform> enemies = new List<Transform>();
    private void Awake()
    {
        enemySpawnPointGenerator = new EnemySpawnPointGenerator(floor, floorWidth, floorLength, minDistanceFromPlayer);
    }
    private void Start()
    {
        if (IsMinDistanceTooBig())
        {
            Debug.LogError("minDistanceFromPlayer is too large. Enemies will not be spawned.");
            return;
        }
    }

    public EnemyBase SpawnEnemy(GameObject enemyToSpawn = null)
    {
        if (enemyToSpawn == null) enemyToSpawn = debugEnemyObject;

        Vector3 spawnPosition = enemySpawnPointGenerator.GenerateSpawnPosition(player.gameObject);

        // Make the enemy look at the player when instantiated
        Vector3 aimDir = (player.position - spawnPosition).normalized;

        // Instantiate enemy at the spawn position
        var enemyObj = Instantiate(enemyToSpawn, spawnPosition, Quaternion.LookRotation(aimDir, Vector3.up));
        enemies.Add(enemyObj.transform);
        enemyObj.SetActive(true);
        return enemyObj.GetComponent<EnemyBase>();
    }

    private bool IsMinDistanceTooBig()
    {
        return minDistanceFromPlayer > floorWidth || minDistanceFromPlayer > floorLength;
    }
}
