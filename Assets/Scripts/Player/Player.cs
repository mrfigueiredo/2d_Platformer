using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public HealthBase healthBase;
    public SO_PlayerSetup so_PlayerSetup;
    public Rigidbody2D rigidBody;
    public BoxCollider2D collider;

    private Animator _currentPlayer;
    private float _currentSpeed;
    private Coroutine _currentJumping;

    private void Awake()
    {
        if (healthBase != null)
            healthBase.OnKill += OnPlayerKill;

        _currentPlayer = Instantiate(so_PlayerSetup.Player, transform);
        GetComponentInChildren<GunBase>().playerReference = this.transform;
    }

    private void OnPlayerKill()
    {
        collider.enabled = false;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(so_PlayerSetup.triggerDeath);
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(so_PlayerSetup.runKey))
        {
            _currentSpeed = so_PlayerSetup.speedRun;
            _currentPlayer.speed = so_PlayerSetup.animationSpeedRun;
        }
        else
        {
            _currentSpeed = so_PlayerSetup.speed;
            _currentPlayer.speed = 1f;
        }



        if (Input.GetKey(so_PlayerSetup.leftKey))
        {
            rigidBody.velocity = new Vector2(-_currentSpeed, rigidBody.velocity.y);
            if (rigidBody.transform.localScale.x != -1)
            {
                rigidBody.transform.DOScaleX(-1, so_PlayerSetup.changeSideDuration);
            }
            _currentPlayer.SetBool(so_PlayerSetup.booleanWalk, true);
        }
        else if (Input.GetKey(so_PlayerSetup.rightKey))
        {
            rigidBody.velocity = new Vector2(_currentSpeed, rigidBody.velocity.y);
            if (rigidBody.transform.localScale.x != 1)
            {
                rigidBody.transform.DOScaleX(1, so_PlayerSetup.changeSideDuration);
            }
            _currentPlayer.SetBool(so_PlayerSetup.booleanWalk, true);
        }
        else
        {
            _currentPlayer.SetBool(so_PlayerSetup.booleanWalk, false);
        }

        if (rigidBody.velocity.x > 0)
        {
            rigidBody.velocity -= so_PlayerSetup.friction;
        }
        else if (rigidBody.velocity.x < 0)
        {
            rigidBody.velocity += so_PlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(so_PlayerSetup.jumpKey))
        {

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, so_PlayerSetup.jumpForce);

            if (_currentJumping == null)
            {
                _currentJumping = StartCoroutine(JumpAnimation());
            }
        }
    }

    private IEnumerator JumpAnimation()
    {
        _currentPlayer.SetTrigger(so_PlayerSetup.triggerJump);
        DOTween.Kill(rigidBody.transform);
        rigidBody.transform.DOScaleY(so_PlayerSetup.jumpStretchY, so_PlayerSetup.jumpStretchDuration).SetEase(so_PlayerSetup.jumpEaseAnimation).SetLoops(2, LoopType.Yoyo);
        rigidBody.transform.DOScaleX(rigidBody.transform.localScale.x * so_PlayerSetup.jumpStretchX, so_PlayerSetup.jumpStretchDuration).SetEase(so_PlayerSetup.jumpEaseAnimation).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(so_PlayerSetup.jumpStretchDuration *2);
        _currentJumping = null;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
