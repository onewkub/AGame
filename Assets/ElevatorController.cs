using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private Animator ElevatorAnimator;
    private AudioSource soundFX;

    private void Awake()
    {
        ElevatorAnimator = GetComponent<Animator>();
        soundFX = GetComponent<AudioSource>();
    }
    
    public void openElevator()
    {
        //yield return new WaitWhile(() => soundFX.isPlaying);

        if (!soundFX.isPlaying)
        {
            Debug.Log("Open Elevator");
            ElevatorAnimator.SetBool("Open", true);
            soundFX.Play();
        }
    }
    
    public void closeElevator()
    {
        //yield return new WaitWhile(() => soundFX.isPlaying);

        if (!soundFX.isPlaying)
        {
            Debug.Log("Close Elevator");
            ElevatorAnimator.SetBool("Open", false);
            soundFX.Play();
        }
    }
}
