using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 0.03f;
    private float turnSpeed = 150.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody RB;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Moves the car forward based on vertical input
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        RB.AddForce(transform.forward * speed * forwardInput, ForceMode.VelocityChange);

        // Rotates the cxar based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation); // on the end of projectil.transform.rotation delete projectile to make it turn with an object
        }
    }
}
