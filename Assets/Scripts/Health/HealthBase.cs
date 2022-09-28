using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int maxLife = 100;
    public bool destroyOnKill = false;
    public float delayToKill = 1f;

    private int _currentLife;
    private bool _isDead;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _currentLife = maxLife;
        _isDead = false;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
            Kill();
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
            Destroy(gameObject, delayToKill);
    }
}
