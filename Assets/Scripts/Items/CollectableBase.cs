using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public ParticleSystem vfxPrefab;
    public string tagToCompare = "Player";

    [Header("Audio")]
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        if (vfxPrefab != null)
            vfxPrefab.Play();

        if (audioSource != null)
            audioSource.Play();
    }
}
