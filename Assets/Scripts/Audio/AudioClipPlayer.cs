using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipPlayer : MonoBehaviour
{
    public List<AudioSource> audioSources;

    [SerializeField]
    public List<AudioClip> audioClips;

    private int _currentIndex;

    private void Awake()
    {
        if (audioSources == null || audioSources.Count == 0)
        {
            var audioSource = new GameObject("AudioSource");
            var source = audioSource.AddComponent<AudioSource>();
            audioSource.transform.parent = this.transform;
            audioSources.Add(source);
        }

        _currentIndex = 0;
    }

    public void Play()
    {
        if (_currentIndex >= audioSources.Count)
            _currentIndex = 0;

        if (audioClips.Count > 0)
        {
            audioSources[_currentIndex].clip = audioClips[0];
            audioSources[_currentIndex].Play();
        }

        _currentIndex++;
    }

    public void PlayRandom()
    {
        if (_currentIndex >= audioSources.Count)
            _currentIndex = 0;

        if (audioClips.Count > 0)
        {
            audioSources[_currentIndex].clip = audioClips[Random.Range(0, audioClips.Count)];
            audioSources[_currentIndex].Play();
        }

        _currentIndex++;
    }
}
