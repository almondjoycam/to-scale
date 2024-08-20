using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeath : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioClip deathSound;

   

    private void OnCollisionEnter2D(Collision2D other) {
            //player hit death zone
        if (other.collider.gameObject.CompareTag("Player")){
            

            //play sound
            audioPlayer.PlayOneShot(deathSound);
            //reset level (reload scene -- object sizes should reset too, this makes it easy)

        }
    }
}
