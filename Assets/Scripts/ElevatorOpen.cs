using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen : MonoBehaviour
{
    public GameObject ElDoor;
    private Animator ElAnimator;
    private AudioSource SoundFX;
    private void Awake()
    {
        ElAnimator = ElDoor.GetComponent<Animator>();
        SoundFX = ElDoor.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ElAnimator.SetBool("Open", true);
            SoundFX.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SoundFX.isPlaying)
            {
                SoundFX.Stop();
            }
            ElAnimator.SetBool("Open", false);
            SoundFX.Play();
        }
    }
}
