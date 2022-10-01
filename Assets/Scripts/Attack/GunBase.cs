using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;
    public Transform shootPosition;
    public float timeBetweenShoots = .5f;

    public KeyCode shootingKey = KeyCode.Space;

    public Transform playerReference;

    private Coroutine _currentShooting;

    private void Update()
    {
        if (Input.GetKey(shootingKey))
        {
            if (_currentShooting == null)
                _currentShooting = StartCoroutine(StartShoot());
        }
    }

    IEnumerator StartShoot()
    {
        Shoot();
        yield return new WaitForSeconds(timeBetweenShoots);
        _currentShooting = null;
    }

    public void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = shootPosition.position;
        projectile.side = playerReference.transform.localScale.x;
    }
}
