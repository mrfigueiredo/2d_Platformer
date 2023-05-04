using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbiencePlaylist : MonoBehaviour
{
    public AudioSource audioSource;

    public List<AudioClip> ambiencePlaylist;


    // Start is called before the first frame update
    void Start()
    {
        PlayRandomMusic();    
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }

    private void PlayRandomMusic()
    {
        audioSource.clip = ambiencePlaylist[Random.Range(0, ambiencePlaylist.Count)];
        audioSource.Play();
    }
}
