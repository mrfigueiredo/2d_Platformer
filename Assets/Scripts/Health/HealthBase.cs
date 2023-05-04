using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthBase : MonoBehaviour
{
    public Action OnKill;

    public int maxLife = 100;
    public bool destroyOnKill = false;
    public float delayToKill = 1f;

    private int _currentLife;
    private bool _isDead;

    [SerializeField]
    private FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
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

        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
            Destroy(gameObject, delayToKill);

        if(OnKill!= null)
            OnKill.Invoke();
    }
}
