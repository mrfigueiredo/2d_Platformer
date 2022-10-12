using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioTransitionSetter : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transitionTime = 0.5f;

    public void SetSnapshot()
    {
        snapshot.TransitionTo(transitionTime);
    }
}
