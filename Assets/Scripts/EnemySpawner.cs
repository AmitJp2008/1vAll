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

        SpawnEnemy();
    }

    public void SpawnEnemy(GameObject enemyToSpawn = null)
    {
        if (enemyToSpawn == null) enemyToSpawn = debugEnemyObject;

        Vector3 spawnPosition = enemySpawnPointGenerator.GenerateSpawnPosition(player.gameObject);

        // Make the enemy look at the player when instantiated
        Vector3 aimDir = (player.position - spawnPosition).normalized;

        // Instantiate enemy at the spawn position
        var enemyObj = Instantiate(enemyToSpawn, spawnPosition, Quaternion.LookRotation(aimDir, Vector3.up));
        enemies.Add(enemyObj.transform);
        enemyObj.SetActive(true);
    }

    private bool IsMinDistanceTooBig()
    {
        return minDistanceFromPlayer > floorWidth || minDistanceFromPlayer > floorLength;
    }
}

public class EnemySpawnPointGenerator
{
    private const int maxSpawnPointGenerationAttempts = 100;
    private Transform floor; // Reference to the floor
    private float floorWidth;
    private float floorLength;
    private float minDistanceFromTarget; // Minimum distance from player

    public EnemySpawnPointGenerator(Transform floorRef, float floorWidth, float floorLenght, float minDistanceFromTarget) 
    {
        floor = floorRef;
        this.floorWidth = floorWidth;
        this.floorLength = floorLenght;
        this.minDistanceFromTarget = minDistanceFromTarget;
    }

    public Vector3 GenerateSpawnPosition(GameObject player)
    {
        Vector3 spawnPosition;

        int maxAttempts = maxSpawnPointGenerationAttempts;
        int attempts = 0;

        while (true)
        {
            float x = Random.Range(floor.position.x - floorWidth / 2f, floor.position.x + floorWidth / 2f);
            float z = Random.Range(floor.position.z - floorLength / 2f, floor.position.z + floorLength / 2f);

            spawnPosition = new Vector3(x, floor.position.y, z);

            if (!GameplayHelper.IsPointInsideSphere(new Vector3(x, 0, z), player.transform.position, minDistanceFromTarget))
            {
                break;
            }

            if (++attempts >= maxAttempts)
            {
                Debug.LogError("Could not find a suitable spawn location within max attempts. Please check your minDistanceFromPlayer value.");
                return Vector3.zero;
            }
        }

        return spawnPosition;
    }
}
