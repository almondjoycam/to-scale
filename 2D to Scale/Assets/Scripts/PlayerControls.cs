using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Vector2 move;
    [SerializeField]
    float speed;
    public float scaleFactor {
        get;
        private set;
    }
    GameMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<GameMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    public void OnScale(InputValue value)
    {
        scaleFactor = value.Get<int>();
    }

    public void OnCancel()
    {
        Time.timeScale = 0.0f;
        menu.PauseResume();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Resizeable"))
        {
            // Resize here
        }
    }
}
