using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public HealthBase healthBase;

    [Header("Animation")]
    public Animator animator;
    public string triggerAttack = "triggerAttack";
    public string triggerDeath = "triggerDeath";

    [Header("Audio")]
    public AudioSource enemyHit;
    public AudioSource enemyDying;

    private void Awake()
    {
        if (healthBase != null)
            healthBase.OnKill += OnEnemyKill;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            AttackAnimation();
        }
    }

    private void OnEnemyKill()
    {
        DeathSound();
        DeathAnimation();
        healthBase.OnKill -= OnEnemyKill;

    }

    private void AttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
        AttackSound();
    }
    private void DeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }
    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }

    private void AttackSound()
    {
        if (enemyHit != null && enemyHit.clip != null)
            enemyHit.Play();
    }

    private void DeathSound()
    {
        if (enemyDying != null && enemyDying.clip != null)
            enemyDying.Play();
    }
}
