using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerHelper : MonoBehaviour
{
    public AudioClipPlayer player;

    private void Awake()
    {
        if (player == null)
        {
            player = this.transform.parent.GetComponentInChildren<AudioClipPlayer>();
        }
    }

    public void Play()
    {
        player.Play();
    }

    public void PlayRandom()
    {
        player.PlayRandom();
    }
}
