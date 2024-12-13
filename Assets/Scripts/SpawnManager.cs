using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Ensure all using statements are at the top
public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;   // Array of enemy prefabs (e.g., zombies)
    public int waveNumber = 1;          // Starting wave number (and initial number of zombies)
    private int defeatedEnemies = 0;    // Track how many enemies have been defeated

    private Vector3 upperLeft = new Vector3(-34.5f, 1.68f, 6.1f);  // Upper-left spawn point
    private Vector3 upperRight = new Vector3(34.5f, 1.68f, 6.1f); // Upper-right spawn point
    private Vector3 lowerLeft = new Vector3(-35.6f, 1.68f, -23.7f); // Lower-left spawn point
    private Vector3 lowerRight = new Vector3(34.5f, 1.68f, -23.7f); // Lower-right spawn point

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the first wave of enemies
        SpawnEnemyWave(waveNumber);  // Spawn zombies equal to waveNumber initially
    }

    // Update is called once per frame
    void Update()
    {
        // Update the current enemy count (if you have Zombie objects)
        int enemyCount = FindObjectsOfType<Zombie>().Length;  // Count the zombies in the scene

        // Check if all enemies are defeated
        if (enemyCount == 0)
        {
            // If all enemies are defeated, spawn the next wave and increment the wave number
            waveNumber += 1;  // Increase wave number by 1 for the next wave

            // Spawn the next wave of enemies (spawn zombies equal to the current wave number)
            SpawnEnemyWave(waveNumber);  // Spawn zombies equal to the current wave number
        }
    }

    // Method to spawn enemies for the current wave
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Loop to spawn the required number of enemies (equals waveNumber)
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Randomly select an enemy prefab from the array
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);

            // Calculate a random spawn position within the bounding box of the four corners
            Vector3 randomSpawnPosition = GetRandomSpawnPosition();

            // Instantiate the selected enemy at the selected spawn position
            Instantiate(enemyPrefabs[randomEnemyIndex], randomSpawnPosition, Quaternion.identity);
        }
    }

    // Method to calculate a random spawn position within the area defined by the four corners
    Vector3 GetRandomSpawnPosition()
    {
        float xMin = Mathf.Min(upperLeft.x, lowerLeft.x);
        float xMax = Mathf.Max(upperRight.x, lowerRight.x);
        float zMin = Mathf.Min(lowerLeft.z, lowerRight.z);
        float zMax = Mathf.Max(upperLeft.z, upperRight.z);

        // Generate random x and z values within the bounding box defined by the four points
        float randomX = Random.Range(xMin, xMax);
        float randomZ = Random.Range(zMin, zMax);

        // Return the new random spawn position (y is fixed)
        return new Vector3(randomX, 1.68f, randomZ);
    }
}





