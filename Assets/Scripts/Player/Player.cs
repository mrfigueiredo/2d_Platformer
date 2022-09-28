using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    [Header("Keys")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;
    public KeyCode runKey = KeyCode.LeftShift;


    [Header("Movement")]
    public float speed = 10f;
    public float speedRun = 20f;
    public float jumpForce = 15;

    [Header("Physics")]
    public Vector2 friction = new Vector2(0.1f, 0f);


    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        _currentSpeed = Input.GetKey(runKey) ? speedRun : speed;


        if(Input.GetKey(leftKey))
        {
            rigidBody.velocity = new Vector2(-_currentSpeed, rigidBody.velocity.y);
        }
        else if(Input.GetKey(rightKey))
        {
            rigidBody.velocity = new Vector2(_currentSpeed, rigidBody.velocity.y);
        }

        if(rigidBody.velocity.x > 0)
        {
            rigidBody.velocity -= friction;
        }
        else if(rigidBody.velocity.x < 0)
        {
            rigidBody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(jumpKey))
        {

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }
}
