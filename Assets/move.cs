using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class move : MonoBehaviour
{
    public float movementSpeed = 10f;
    Animator animator;
    Rigidbody2D rb;
    public Text scoreText;
    float movement = 0f;
    private float levelWidth = 10;
    private float topScore = 0.0f;
    private AudioSource audioSource;
    private bool isDead = false; // Flag to indicate if the hero is dead

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return; // Stop updating if the hero is dead

        exitScreen();
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 3f)
        {
            Die();
            audioSource.Play();
            Invoke("ReloadScene", 1.5f); // Call a method that ends the game
        }
    }

    void FixedUpdate()
    {
        if (isDead) return; // Stop updating if the hero is dead

        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            audioSource.Play();
            animator.SetTrigger("Death");  // Trigger the death animation
            Die();
            Invoke("ReloadScene", 1.5f);  // Delay scene reload to allow the death animation to play
        }
    }

    public void Die()
    {
        isDead = true;  // Set the flag to indicate the hero is dead
        rb.velocity = Vector2.zero;  // Stop any movement
        rb.isKinematic = true;  // Disable physics
        this.enabled = false;  // Disable this script
    }

    void ReloadScene()
    {
        GameData.LastScore = Mathf.RoundToInt(topScore);
        SceneManager.LoadScene("End");  // Reload the scene after the animation
    }

    private void exitScreen()
    {
        if (transform.position.x > levelWidth)
        {
            transform.position -= new Vector3(2 * levelWidth, 0, 0);
        }
        else if (transform.position.x < -levelWidth)
        {
            transform.position += new Vector3(2 * levelWidth, 0, 0);
        }
    }
}
