using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : MonoBehaviour
{
    public AudioSource[] SoundFXs;
    public void AttackToElevator()
    {
        if(SoundFXs[0] != null)
        {
            SoundFXs[0].Play();
        }
    }
    public bool AttackSoundIsPlaying()
    {
        return SoundFXs[0].isPlaying;
    }
}
