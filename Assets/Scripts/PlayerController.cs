using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public Animator animator;
    Rigidbody2D rigidbody; //Para controlar el rigidbody que tiene nuestro personaje
    Vector2 input; //Asignar el movimiento tanto en el eje X como en el Y

    [Header("Movement Variables")]
    public float movementSpeed; //Para darle una velocidad de movimiento mayor a 1 o -1 a nuestro personaje
    public int direction; //Para asignar a donde mira nuestro personaje

    [Header("Jump Variables")]
    public float jumpForce;
    public bool doubleJump = true;

    [Header("Ground Check Variables")]
    public Transform groundCheckPoint;
    public float radius;
    public LayerMask whatIsGround;
    bool isGrounded;

    void Start()
    {
        //Asigno el rigidbody que tiene nuestro componente, enlanzandolo
        //Con la variable rigidbody que creamos
        rigidbody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        //Para que mire hacia la derecha
        direction = 1;
        //Para que el sprite se rote y vea hacia la derecha.
        FlipSprite();
    }

    void Update()
    {
        //Llamamos a la función Movement, si no esta en un update, no va a ejecutarse
        Movement();

        GroundCheck();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    //Esta función maneja el movimiento horizontal del personaje
    void Movement()
    {
        input = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, rigidbody.velocity.y);

        //Si miras a la derecha, entonces asigna 1 a direction (le dices que mire hacia la derecha al sprite)
        if (input.x > 0)
        {
            direction = 1;
            FlipSprite();
        }
        //Si miras a la izquierda, entonces asigna -1 a direction (le dices que mire hacia la izquierda al sprite)
        else if (input.x < 0)
        {
            direction = -1;
            FlipSprite();
        }

        animator.SetBool("isWalking", Mathf.Abs(input.x) > 0);

        //Rigidbody es un componente que hace que nuestro objeto sea afectado por físicas
        //En esta línea asignamos tanto la velocidad en el eje X, como en el eje Y
        rigidbody.velocity = input;
    }

    void Jump()
    {
        if (isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce * Time.deltaTime);
            animator.SetBool("isGrounded", false);
        }
        else if (doubleJump)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce * Time.deltaTime);
            doubleJump = false;
            animator.SetBool("isGrounded", false);
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, radius, whatIsGround);

        if (isGrounded)
        {
            doubleJump = true;
            animator.SetBool("isGrounded", true);
        }
    }

    void FlipSprite()
    {
        float yAxisRotation = 0;
        if (direction == 1)
            yAxisRotation = 180;
        transform.eulerAngles = new Vector3(0, yAxisRotation, 0);
    }
}
