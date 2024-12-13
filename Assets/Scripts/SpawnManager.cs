using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Ensure all using statements are at the top
public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;   // Array of enemy prefabs (e.g., zombies)
    public GameObject[] spawnPositions; // Array of spawn positions
    public int waveNumber = 1;          // Starting wave number (and initial number of zombies)
    private int defeatedEnemies = 0;    // Track how many enemies have been defeated

    // Start is called before the first frame update
    void Start()
    {
        // Initialize spawn positions if they aren't assigned manually
        InitializeSpawnPositions();

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
            // If all enemies are defeated, increase the wave number and spawn the next wave
            defeatedEnemies += waveNumber;

            // Increment waveNumber by 1, so the next wave will have one more zombie than the previous one
            waveNumber += 1;  // Increase wave number by 1 for the next wave

            // Spawn the next wave of enemies
            SpawnEnemyWave(waveNumber);  // Spawn zombies equal to the current wave number
        }
    }

    // Method to initialize spawn positions if not assigned
    void InitializeSpawnPositions()
    {
        // Initialize the spawnPositions array with 4 spawn points if not manually set
        spawnPositions = new GameObject[4];

        // Create and set spawn points at each of the four corners
        spawnPositions[0] = CreateSpawnPoint(new Vector3(-10, 2, 10));  // Top-left corner
        spawnPositions[1] = CreateSpawnPoint(new Vector3(10, 2, 10));   // Top-right corner
        spawnPositions[2] = CreateSpawnPoint(new Vector3(-10, 2, -10)); // Bottom-left corner
        spawnPositions[3] = CreateSpawnPoint(new Vector3(10, 2, -10));  // Bottom-right corner
    }

    // Method to create a spawn point GameObject at a given position
    GameObject CreateSpawnPoint(Vector3 position)
    {
        GameObject spawnPoint = new GameObject("SpawnPoint");
        spawnPoint.transform.position = position;
        return spawnPoint;
    }

    // Method to spawn enemies for the current wave
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Loop to spawn the required number of enemies (equals waveNumber)
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Randomly select an enemy prefab from the array
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);

            // Randomly select a spawn position from the spawn positions array
            int randomSpawnIndex = Random.Range(0, spawnPositions.Length);

            // Get the random spawn position
            Vector3 spawnPosition = spawnPositions[randomSpawnIndex].transform.position;

            // Instantiate the selected enemy at the selected spawn position
            Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, Quaternion.identity);
        }
    }
}





