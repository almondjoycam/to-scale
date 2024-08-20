using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    // Movement and Physics
    public bool allDirectionMovement;

    Rigidbody2D rb;
    Vector2 move;
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;
    float gravityForce;
    bool isGrounded = false;
    Collider2D groundCollider = null;

    // Gameplay
    [SerializeField]
    float scaleFactor;
    float scaleInput;
    [SerializeField]
    [Range(0.0f, 2.0f)]
    float sizeTime = 0.5f;
    IResizeable resizeable = null;
    ObjectResizer embiggen = new ObjectResizer();
    ObjectResizer shrinkify = new ObjectResizer();

    GameMenu menu;

    // Sprite and Animation
    SpriteRenderer rend;




    // Start is called before the first frame update
    void Start()
    {
        gravityForce = Physics2D.gravity.y;
        menu = FindObjectOfType<GameMenu>();

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rend = GetComponent<SpriteRenderer>();

        embiggen.SetScaleFactor(scaleFactor);
        shrinkify.SetScaleFactor(1.0f / scaleFactor);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Grounding and Gravity
        if (!isGrounded)
        {
            move.y += Time.fixedDeltaTime * gravityForce * rb.mass;
        }

        rb.MovePosition((Vector2)transform.position
            + (move * Time.fixedDeltaTime));

        // Direction
        if (move.x < 0)
        {
            rend.flipX = true;
        }
        else if (move.x > 0)
        {
            rend.flipX = false;
        }

        if (scaleInput != 0)
        {
            PlayerResize();
        }
    }

    public void OnMove(InputValue value)
    {
        if (allDirectionMovement)
        {
            move = value.Get<Vector2>() * speed;
        }
        else
        {
            move.x = value.Get<Vector2>().x * speed;
        }
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            Gravity(true);
            move.y = jumpForce;
//             rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

//     IEnumerator JumpRoutine()
//     {
//         for (float f =
//     }

    void Gravity(bool dynamic)
    {
        if (dynamic)
        {
            rb.isKinematic = false;
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
            //rb.velocity = Vector2.zero;
            move.y = 0;
//             rb.isKinematic = true;
        }
    }

    public void OnScale(InputValue value)
    {
        scaleInput = value.Get<float>();
    }

    public void OnCancel()
    {
        menu.PauseResume();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == 3
            && other.GetContact(0).normal.y == 1)
        {
            Gravity(false);
            groundCollider = other.collider;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        GameObject otherObj = other.collider.gameObject;
        resizeable = otherObj.GetComponent<IResizeable>();
        if (otherObj.layer == 3
            && other.GetContact(0).normal.y == 1)  // Ground layer
        {
            Gravity(false);
            groundCollider = other.collider;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        GameObject otherObj = other.collider.gameObject;
        resizeable = null;
        if (other.collider.gameObject.layer == 3)
        {
            Gravity(true);
            groundCollider = null;
        }
    }

    void PlayerResize()
    {
        if (resizeable == null)
        {
            return;
        }
        transform.SetParent(resizeable.GetTransform());
        if (scaleInput < 0)
        {
            shrinkify.ResizeObject(resizeable, sizeTime);
        }
        else if (scaleInput > 0)
        {
            embiggen.ResizeObject(resizeable, sizeTime);
        }
        transform.SetParent(null);
    }
}
