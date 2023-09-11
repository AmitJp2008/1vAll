using UnityEngine;

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
