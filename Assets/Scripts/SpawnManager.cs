using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Ensure all using statements are at the top

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] enemyPrefabs;

    // Predefined spawn positions
    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(32.55f, 1.152101f, -27.56f),
        new Vector3(32.55f, 1.152101f, 5.8f),
        new Vector3(-34.2f, 1.152101f, 5.8f),
        new Vector3(-34.2f, 1.152101f, -26f)
    };

    private int defeatedEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the first wave of enemies
        SpawnEnemyWave(this.waveNumber);  // Use 'this' to avoid ambiguity
    }

    // Update is called once per frame
    void Update()
    {
        // Update the current enemy count
        this.enemyCount = FindObjectsOfType<Zombie>().Length;  // Use 'this' to avoid ambiguity

        // Check if all enemies are defeated
        if (this.enemyCount == 0)  // Use 'this' to avoid ambiguity
        {
            // Update defeated enemies count and calculate the next wave size
            this.defeatedEnemies += this.waveNumber;  // Use 'this' to avoid ambiguity
            this.waveNumber = this.defeatedEnemies * 2;  // Spawn twice the amount defeated
            // Spawn the next wave
            SpawnEnemyWave(this.waveNumber);  // Use 'this' to avoid ambiguity
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int spawnPosIndex = 0;

        // Ensure enemiesToSpawn does not exceed the available spawn positions
        int enemiesToSpawnAdjusted = Mathf.Min(enemiesToSpawn, spawnPositions.Length);

        for (int i = 0; i < enemiesToSpawnAdjusted; i++)
        {
            // Select a random enemy prefab from the list
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);  // Use 'this' to avoid ambiguity

            // Use the predefined spawn positions
            Vector3 spawnPosition = spawnPositions[spawnPosIndex];

            // Instantiate the selected enemy at the spawn position
            Instantiate(enemyPrefabs[randomEnemy], spawnPosition, enemyPrefabs[randomEnemy].transform.rotation);

            // Update the spawn position index (looping back if necessary)
            spawnPosIndex = (spawnPosIndex + 1) % spawnPositions.Length;
        }
    }
}



