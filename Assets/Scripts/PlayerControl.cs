using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    private float speed = 5.0f; // Adjust speed for more realistic movement
    private float turnSpeed = 200.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody RB;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        // Lock the rotation of the Rigidbody to prevent unwanted spinning
        RB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for horizontal (left-right) and forward (up-down) movement
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Calculate the movement vector based on the player's local space
        Vector3 movement = (transform.forward * forwardInput + transform.right * horizontalInput) * speed;

        // Apply the movement to the Rigidbody
        RB.velocity = new Vector3(movement.x, RB.velocity.y, movement.z); // Keep vertical velocity unchanged

        // Rotate the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        // Fire projectile when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
        }
    }
}



