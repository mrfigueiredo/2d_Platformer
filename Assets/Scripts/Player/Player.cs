using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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


    [Header("Animation")]
    public Animator animator;

    public string booleanWalk = "boolWalk";
    public string triggerJump = "triggerJump";
    public float animationSpeedRun = 2f;
    public float jumpStretchX = 0.7f;
    public float jumpStretchY = 1.2f;
    public float jumpStretchDuration = 0.2f;
    public Ease jumpEaseAnimation = Ease.OutBack;
    public float changeSideDuration = 0.2f;

    private float _currentSpeed;


    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(runKey))
        {
            _currentSpeed = speedRun;
            animator.speed = animationSpeedRun;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1f;
        }



        if (Input.GetKey(leftKey))
        {
            rigidBody.velocity = new Vector2(-_currentSpeed, rigidBody.velocity.y);
            if (rigidBody.transform.localScale.x != -1)
            {
                rigidBody.transform.DOScaleX(-1, changeSideDuration);
            }
            animator.SetBool(booleanWalk, true);
        }
        else if (Input.GetKey(rightKey))
        {
            rigidBody.velocity = new Vector2(_currentSpeed, rigidBody.velocity.y);
            if (rigidBody.transform.localScale.x != 1)
            {
                rigidBody.transform.DOScaleX(1, changeSideDuration);
            }
            animator.SetBool(booleanWalk, true);
        }
        else
        {
            animator.SetBool(booleanWalk, false);
        }

        if (rigidBody.velocity.x > 0)
        {
            rigidBody.velocity -= friction;
        }
        else if (rigidBody.velocity.x < 0)
        {
            rigidBody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey))
        {

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

            JumpAnimation();
        }
    }

    private void JumpAnimation()
    {
        animator.SetTrigger(triggerJump);
        DOTween.Kill(rigidBody.transform);
        rigidBody.transform.DOScaleY(jumpStretchY, jumpStretchDuration).SetEase(jumpEaseAnimation).SetLoops(2, LoopType.Yoyo);
        rigidBody.transform.DOScaleX(rigidBody.transform.localScale.x * jumpStretchX, jumpStretchDuration).SetEase(jumpEaseAnimation).SetLoops(2, LoopType.Yoyo);
    }
}
