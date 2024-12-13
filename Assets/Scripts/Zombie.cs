using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        // Find all objects with the "Obstacle" tag
        GameObject[] obstacleObjects = GameObject.FindGameObjectsWithTag("Obstacle");

        // Loop through the found objects and ignore collisions with them
        foreach (GameObject obstacle in obstacleObjects)
        {
            Collider obstacleCollider = obstacle.GetComponent<Collider>(); // Get the Collider component from the obstacle
            if (obstacleCollider != null)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), obstacleCollider); // Ignore collision with the obstacle
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is null to prevent the MissingReferenceException
        if (player == null)
        {
            return; // If player is destroyed, stop the update logic for this zombie
        }

        // Calculate the direction towards the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Move the zombie towards the player
        enemyRb.AddForce(lookDirection * speed);

        // Optional: Destroy the zombie if it falls below a certain height (e.g., off the map)
        if (transform.position.y < -10)
        {
            Destroy(gameObject); // This will destroy the zombie if it falls off the map
        }
    }

    // When the zombie collides with something, it will disappear (destroy itself)
    private void OnCollisionEnter(Collision collision)
    {
        // If the zombie collides with an obstacle, it does NOT despawn
        // Keep the zombies alive, they don't get destroyed by collisions with obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // The zombie won't despawn when hitting an obstacle; no need for any additional code here.
            // You can optionally add logic to handle what happens when they hit the wall (e.g., bounce, change direction, etc.)
        }
    }
}

