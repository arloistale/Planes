using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab; 
    public int numberOfAsteroids = 10; 
    public float spawnRadius = 10.0f;

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
            Asteroid asteroid = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
            asteroid.transform.SetParent(transform);
            asteroid.Push();
        }
    }
}
