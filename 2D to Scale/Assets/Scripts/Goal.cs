using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioClip winSound;

    void Start(){
        audioPlayer.PlayOneShot(winSound); //test
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        //Win condition
        if (other.collider.gameObject.CompareTag("Player")){
            //Congratulatory Sound
            audioPlayer.PlayOneShot(winSound);
            
            //Load Scene

        }

    }
}
