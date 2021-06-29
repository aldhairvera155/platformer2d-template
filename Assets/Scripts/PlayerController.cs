using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody; //Para controlar el rigidbody que tiene nuestro personaje
    public float movementSpeed; //Para darle una velocidad de movimiento mayor a 1 o -1 a nuestro personaje
    public int direction; //Para asignar a donde mira nuestro personaje
    public Vector2 input; //Asignar el movimiento tanto en el eje X como en el Y

    void Start()
    {
        //Asigno el rigidbody que tiene nuestro componente, enlanzandolo
        //Con la variable rigidbody que creamos
        rigidbody = GetComponent<Rigidbody2D>();
        direction = 1;
        FlipSprite();
    }

    void Update()
    {
        //Llamamos a la función Movement, si no esta en un update, no va a ejecutarse
        Movement();
    }

    //Esta función maneja el movimiento horizontal del personaje
    void Movement()
    {
        //Este Vector2 contiene el movimiento horizontal del personaje que proviene de
        //El input (presionar sea el botón A,D o flecha izquierda o derecha) que en este caso nos da valores
        //entre -1 y 1 (-1,-0.9,-0.8,-0.7,... ,0.8,0.9,1)
        //Multiplicado por movementSpeed, para que se mueva un poco más rápido
        //Time.deltaTime nos da independencia en los frames para que nuestro juego se sienta
        //Igual en cualquier computador
        //rigidbody.velocity.y -> asigna la gravedad del objeto.
        input = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, rigidbody.velocity.y);

        if (input.x > 0)
        {
            direction = 1;
            FlipSprite();
        }
        else if (input.x < 0)
        {
            direction = -1;
            FlipSprite();
        }

        //Rigidbody es un componente que hace que nuestro objeto sea afectado por físicas
        //En esta línea asignamos tanto la velocidad en el eje X, como en el eje Y
        rigidbody.velocity = input;
    }

    void FlipSprite()
    {
        float yAxisRotation = 0;
        if (direction == 1)
            yAxisRotation = 180;
        transform.eulerAngles = new Vector3(0, yAxisRotation, 0);
    }
}
