using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EndLevel : MonoBehaviour
{
    public UnityEvent OnEndLevel;
    public string tagToCompare = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCompare))
        {
            OnEndLevel?.Invoke();
        }
    }
}
