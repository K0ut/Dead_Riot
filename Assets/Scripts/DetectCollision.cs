using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private int objectsDestroyed = 0; // Counter for destroyed objects

    // Update is called once per frame
    void Update()
    {
        // You can handle other game logic here if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroy this object
        Destroy(other.gameObject); // Destroy the other object

        objectsDestroyed++; // Increment the counter
        CheckGameOver(); // Check for game over condition
    }

    private void CheckGameOver()
    {
        if (objectsDestroyed >= 6)
        {
            // Trigger game over logic here
            GameOver();
        }
    }

    private void GameOver()
    {
        // Implement game over logic, such as displaying a UI message or stopping the game
        Debug.Log("Game Over! You destroyed 6 objects.");

    }
}
