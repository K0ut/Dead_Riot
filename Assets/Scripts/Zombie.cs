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

        // Find all objects with the "Obstacle" tag and ignore collision with them
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

    // When the zombie collides with something, it will not despawn (does not destroy itself)
    private void OnCollisionEnter(Collision collision)
    {
        // Debug: Log the collision to see which object the zombie collides with
        Debug.Log($"Zombie collided with: {collision.gameObject.name}");

        // If the zombie collides with an obstacle, it does NOT despawn
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // The zombie won't despawn when hitting an obstacle; no need for any additional code here.
            return; // No need to destroy or do anything else.
        }

        // If the zombie collides with another zombie, it should NOT despawn
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // The zombies won't despawn upon collision with another zombie
            // They can continue their behavior without destruction.
            // You can optionally make them react in another way, but they won't be destroyed here.
            return; // Prevent any destruction logic for zombie-on-zombie collisions.
        }

        // Other collision logic can be added here, for example, if zombies hit the player or certain items.
    }
}

