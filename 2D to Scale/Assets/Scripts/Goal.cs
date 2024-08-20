using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioClip winSound;
    [SerializeField]
    int nextLevelIndex;
    [SerializeField]
    GameObject victoryScreen;

    void Start()
    {
        audioPlayer = FindObjectOfType<AudioSource>();
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        //Win condition
        if (other.collider.gameObject.CompareTag("Player")){
            //Congratulatory Sound
            audioPlayer.PlayOneShot(winSound);
            
            //Load Scene
            victoryScreen.SetActive(true);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }
}
