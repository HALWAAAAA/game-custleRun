using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Assuming the player has the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            animator = player.GetComponent<Animator>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (animator != null)
            {
                animator.SetTrigger("Death");
                // Trigger the death animation
                collision.gameObject.GetComponent<move>().Die();
            }
            else
            {
                Debug.LogError("Animator component not found on the player.");
            }
        }
    }
}

