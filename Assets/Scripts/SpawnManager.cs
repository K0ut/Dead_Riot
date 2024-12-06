using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Ensure all using statements are at the top

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;   // Array of zombie enemy prefabs
    public GameObject[] spawnPositions; // Array of spawn positions
    public int waveNumber = 1;          // Starting wave number
    private int defeatedEnemies = 0;     // Track how many enemies have been defeated

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the first wave of enemies
        SpawnEnemyWave(waveNumber);  // Spawn initial wave
    }

    // Update is called once per frame
    void Update()
    {
        // Update the current enemy count
        int enemyCount = FindObjectsOfType<Zombie>().Length;  // Ensure to count the zombies in the scene

        // Check if all enemies are defeated
        if (enemyCount == 0)
        {
            // Double the number of enemies for the next wave
            defeatedEnemies += waveNumber;
            waveNumber = defeatedEnemies * 2;  // Multiply the wave number by 2 after each wave

            // Spawn the next wave of enemies
            SpawnEnemyWave(waveNumber);
        }
    }

    // Method to spawn the enemies for the current wave
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Loop to spawn the required number of enemies
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



