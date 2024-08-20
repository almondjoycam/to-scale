using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDeath : MonoBehaviour
{

    AudioSource audioPlayer;
    public AudioClip deathSound;

    PlayerControls player;

    void Start()
    {
        audioPlayer = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
            //player hit death zone
        if (other.gameObject.CompareTag("Player")){
            player = other.gameObject.GetComponent<PlayerControls>();
            //play sound
            audioPlayer.PlayOneShot(deathSound);
            //reset level
            // object sizes should reset too, thismakes it easy)
            Invoke("ReloadScene", deathSound.length);
        }
    }

    void ReloadScene()
    {
        if (player)
        {
            player.OnReset();
        }
    }
}

