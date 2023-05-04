using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioJumpPlayer : MonoBehaviour
{
    public AudioSource source;

    public void Jump()
    {
        source.Play();
    }

}
