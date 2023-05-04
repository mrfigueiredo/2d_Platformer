using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string sliderParam;

    public void ChangeVolume(float volume)
    {
        mixer.SetFloat(sliderParam, volume);
    }
}
