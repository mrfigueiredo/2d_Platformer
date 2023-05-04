using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGunSFX : MonoBehaviour
{
    public AudioSource source;

    public AudioClip shootClip;

    private void Awake()
    {
        source.clip = shootClip;
    }

    public void ShootSound()
    {
        source.Play();
    }
}
