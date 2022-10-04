using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_PlayerSetup : ScriptableObject
{
    public Animator Player;

    [Header("Keys")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;
    public KeyCode runKey = KeyCode.LeftShift;


    [Header("Movement")]
    public float speed = 10f;
    public float speedRun = 20f;
    public float jumpForce = 25;

    [Header("Physics")]
    public Vector2 friction = new Vector2(0.5f, 0f);


    [Header("Animation")]
    public string booleanWalk = "boolWalk";
    public string triggerJump = "triggerJump";
    public string triggerDeath = "triggerDeath";
    public float animationSpeedRun = 2f;
    public float jumpStretchX = 0.7f;
    public float jumpStretchY = 1.2f;
    public float jumpStretchDuration = 0.2f;
    public Ease jumpEaseAnimation = Ease.OutBack;
    public float changeSideDuration = 0.2f;

}
