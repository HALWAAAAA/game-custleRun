using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncy_main : MonoBehaviour
{
    private AudioSource audioSource;
    public float jumpForce = 10f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Get the AudioSource component
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rigidbody = collision.collider.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                Vector2 velocity = rigidbody.velocity;
                velocity.y = jumpForce;
                rigidbody.velocity = velocity;
                audioSource.Play();
            }
        }
    }
}
