using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Drag your Asteroid prefab here
    public int numberOfAsteroids = 10; // Number of asteroids you want to spawn
    public float spawnRadius = 10.0f; // Radius in which asteroids will be spawned

    void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            // Generate a random position within the spawnRadius
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;

            // Add the position to the current position of the GameObject this script is attached to
            randomPosition += transform.position;

            // Instantiate the asteroid at the randomPosition
            Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
        }
    }
}
