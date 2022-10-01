using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0);
    public float timeToLive = 2f;
    public float side = 1;
    public int damageAmount = 10;

    private string playerTag = "Player";

    private void Awake()
    {
        Destroy(gameObject, timeToLive);
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * Mathf.Sign(side));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
            return;

        var enemy = other.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.Damage(damageAmount);
        }

        Destroy(gameObject);
    }
}