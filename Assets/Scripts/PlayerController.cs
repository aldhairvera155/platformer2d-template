using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float movementSpeed;
    public int direction;
    public Vector2 input;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        input = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rigidbody.velocity.y);
        rigidbody.velocity = input;
    }
}
