using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{
    public float minRadius = 0.5f; // Minimum radius for randomization
    public float maxRadius = 5f; // Maximum radius for randomization
    public float minSpeed = 0.5f; // Minimum speed for randomization
    public float maxSpeed = 3f; // Maximum speed for randomization

    private float radius; // The radius of the circular path
    private float speed; // The speed of the movement
    private Vector3 centerPosition; // The center point of the circular path
    private float angle; // The current angle

    void Start()
    {
        // Randomize the radius and speed within the specified ranges
        radius = Random.Range(minRadius, maxRadius);
        speed = Random.Range(minSpeed, maxSpeed);

        // Set the initial center position
        centerPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position
        angle += speed * Time.deltaTime; // Increment the angle based on the speed
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Get the main camera
        Camera mainCamera = Camera.main;

        // Calculate the screen boundaries in world coordinates
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Calculate the x boundaries to keep the platform within the screen horizontally
        float leftBoundary = mainCamera.transform.position.x - screenWidth / 2f;
        float rightBoundary = mainCamera.transform.position.x + screenWidth / 2f;

        // Update the platform's position and clamp the x value
        Vector3 newPosition = new Vector3(centerPosition.x + x, centerPosition.y + y, centerPosition.z);
        newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary + radius, rightBoundary - radius);

        transform.position = newPosition;
    }
}