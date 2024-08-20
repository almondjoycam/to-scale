using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioClip winSound;
    [SerializeField]
    string nextLevelName;

    void Start()
    {
        audioPlayer = FindObjectOfType<AudioSource>();
//         audioPlayer.PlayOneShot(winSound); //test
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        //Win condition
        if (other.collider.gameObject.CompareTag("Player")){
            //Congratulatory Sound
            audioPlayer.PlayOneShot(winSound);
            
            //Load Scene
            Invoke("NextScene", winSound.length);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
