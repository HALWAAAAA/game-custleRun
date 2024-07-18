using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float minRadius = 0.5f; // Minimum radius for randomization
    public float maxRadius = 4f; // Maximum radius for randomization
    public float minSpeed = 0.5f; // Minimum speed for randomization
    public float maxSpeed = 5f; // Maximum speed for randomization

    private float radius; // The radius of the horizontal movement
    private float speed; // The speed of the movement
    private Vector3 startPosition; // The start position of the platform
    private bool movingRight; // Direction of movement

    void Start()
    {
        // Randomize the radius and speed within the specified ranges
        radius = Random.Range(minRadius, maxRadius);
        speed = Random.Range(minSpeed, maxSpeed);

        // Set the initial start position
        startPosition = transform.position;

        // Start moving to the right
        movingRight = true;
    }

    void Update()
    {
        // Calculate the new position
        float xMovement = speed * Time.deltaTime * (movingRight ? 1 : -1);

        // Get the main camera
        Camera mainCamera = Camera.main;

        // Calculate the screen boundaries in world coordinates
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Calculate the x boundaries to keep the platform within the screen horizontally
        float leftBoundary = mainCamera.transform.position.x - screenWidth / 2f;
        float rightBoundary = mainCamera.transform.position.x + screenWidth / 2f;

        // Update the platform's position
        Vector3 newPosition = new Vector3(transform.position.x + xMovement, startPosition.y, startPosition.z);

        // Check if the platform is going out of the radius boundaries and reverse direction if needed
        float leftLimit = startPosition.x - radius;
        float rightLimit = startPosition.x + radius;

        // Ensure the platform stays within the screen horizontally
        if (newPosition.x < leftBoundary + radius || newPosition.x > rightBoundary - radius)
        {
            movingRight = !movingRight;
            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary + radius, rightBoundary - radius);
        }

        // Reverse direction if out of limits
        if (newPosition.x < leftLimit)
        {
            movingRight = true;
            newPosition.x = leftLimit;
        }
        else if (newPosition.x > rightLimit)
        {
            movingRight = false;
            newPosition.x = rightLimit;
        }

        transform.position = newPosition;
    }
}
