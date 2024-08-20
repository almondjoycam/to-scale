using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDeath : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioClip deathSound;

    int currentSceneIndex;

    void Start()
    {
        audioPlayer = FindObjectOfType<AudioSource>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other) {
            //player hit death zone
        if (other.gameObject.CompareTag("Player")){
            //play sound
            audioPlayer.PlayOneShot(deathSound);
            //reset level
            // object sizes should reset too, thismakes it easy)
            Invoke("ReloadScene", deathSound.length);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}

