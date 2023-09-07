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

    private List<Transform> enemies = new List<Transform>();
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

        Vector3 spawnPosition = GenerateSpawnPosition();

        // Make the enemy look at the player when instantiated
        Vector3 aimDir = (player.position - spawnPosition).normalized;

        // Instantiate enemy at the spawn position
        var enemyObj = Instantiate(enemyToSpawn, spawnPosition, Quaternion.LookRotation(aimDir, Vector3.up));
        enemies.Add(enemyObj.transform);
        enemyObj.SetActive(true);
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        int maxAttempts = 100;
        int attempts = 0;

        while (true)
        {
            float x = Random.Range(floor.position.x - floorWidth / 2f, floor.position.x + floorWidth / 2f);
            float z = Random.Range(floor.position.z - floorLength / 2f, floor.position.z + floorLength / 2f);

            spawnPosition = new Vector3(x, floor.position.y, z);

            if (!GameplayHelper.IsPointInsideSphere(new Vector3(x, 0, z), player.transform.position, minDistanceFromPlayer))
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

   

    private bool IsMinDistanceTooBig()
    {
        return minDistanceFromPlayer > floorWidth || minDistanceFromPlayer > floorLength;
    }
}
