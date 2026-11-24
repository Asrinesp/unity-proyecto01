using UnityEngine;
using UnityEngine.InputSystem;

public class MonstroController : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    [SerializeField]
    float jump, megaJump;

    Rigidbody2D rb;
    Animator ator;

    bool isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 direction = new Vector2(0f, 0f);

        // direcciones
        if (Keyboard.current.dKey.isPressed)
        {
            direction.x = 1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            direction.x = -1f;
        }

        Vector2 velocity = direction * speed;
        // respetar el movimiento vertical que ya tenia
        velocity = new Vector2(velocity.x, rb.linearVelocityY);

        // saltar
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            velocity.y = jump;
        }
        // super salto
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = megaJump;
        }
        */

        ator.SetFloat("speedX", rb.linearVelocityX);
        ator.SetFloat("speedY", rb.linearVelocityY);


        Vector2 velocity = new Vector2(0f, 0f);
        if (Keyboard.current.dKey.isPressed)
            velocity.x = speed;
        else
            if (Keyboard.current.aKey.isPressed)
                velocity.x = -speed;

        velocity.y = rb.linearVelocityY;

        // Comprobamos el salto
        // Solo saltamos si no se esta saltando ya
        if (!isJumping)
        {
            isJumping = true;
            if (Keyboard.current.wKey.wasPressedThisFrame)
                velocity.y = jump;
            else
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    ator.SetTrigger("megaJump");
                    velocity.y = megaJump;
                }
                else
                    isJumping = false;
        }
        else 
        {
            if (rb.linearVelocityY < 0f)
                isJumping = false;
        }

        rb.linearVelocity = velocity;
    }
}
