using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClickSound()
    {
        audioSource.Play();  // Play the click sound
    }
    public void startGame()
    {
        PlayClickSound();
        SceneManager.LoadScene("Main");
    }
    public void QuitGame()
    {
        PlayClickSound();
        Debug.Log("Quitting game");  // Log message to confirm the quit function works (Only appears in editor)
        Application.Quit();
    }
}
