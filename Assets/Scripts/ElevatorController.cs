using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    public static ElevatorController Instance { get; set; }

    private Animator ElevatorAnimator;
    private AudioSource soundFX;

    private void Awake()
    {
        ElevatorAnimator = GetComponent<Animator>();
        soundFX = GetComponent<AudioSource>();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    public void openElevator()
    {
        //yield return new WaitWhile(() => soundFX.isPlaying);
        //Debug.Log("Open Elevator");
        ElevatorAnimator.SetBool("Open", true);
        soundFX.Play();

    }
    
    public void closeElevator()
    {
        //yield return new WaitWhile(() => soundFX.isPlaying);

        //Debug.Log("Close Elevator");
        ElevatorAnimator.SetBool("Open", false);
        soundFX.Play();
    }

    public bool SoundFXisPlaying()
    {
        return soundFX.isPlaying;
    }
}
