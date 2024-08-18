using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    // Movement configuration
    Vector2 move;
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;
    public bool allDirectionMovement;

    // Physics
    Rigidbody2D rb;
    bool isGrounded;

    // Gameplay
    public float scaleFactor {
        get;
        private set;
    }
    ObjectResizer embiggen = new ObjectResizer();
    ObjectResizer shrinkify = new ObjectResizer();
    GameMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<GameMenu>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        embiggen.SetScaleFactor(2);
        shrinkify.SetScaleFactor(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        if (!allDirectionMovement)
        {
            move.y = 0;
        }
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            rb.isKinematic = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
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
        if (other.collider.gameObject.CompareTag("Resizeable"))
        {
            if (scaleFactor < 0)
            {
                shrinkify.ResizeObject(other.collider.gameObject);
            }
            else if (scaleFactor > 0)
            {
                embiggen.ResizeObject(other.collider.gameObject);
            }
        }
        else if (other.collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.isKinematic = true;
        }
    }
}
