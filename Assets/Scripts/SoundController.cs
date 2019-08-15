using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance { get; set; }
    public AudioSource BGMusic;
    public AudioSource ElevatorArrive;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        BGMusic.Play();
    }
    public void EleavotorArrivePlay()
    {
        ElevatorArrive.Play();
    }
}
