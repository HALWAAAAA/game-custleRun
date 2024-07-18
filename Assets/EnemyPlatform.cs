using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPlatform : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assumes your hero has the tag "Player"
        {
            if (animator != null)
            {
                animator.SetTrigger("Death");
                // Trigger the death animation
                Invoke("ReloadScene", 1.5f);
            }
            else
            {
                Debug.LogError("Animator component not found on the player.");
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("End");  // Reload the scene after the animation
    }
}

