using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PauseResume()
    {
        if (!paused)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            paused = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            paused = false;
        }
    }


    public void Quit()
    {
        Application.Quit();
    }
}
