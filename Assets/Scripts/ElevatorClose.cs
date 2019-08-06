using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorClose : MonoBehaviour
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
        if (other.gameObject.tag == "Player" && SceneEventFirstFloor.Instance.pass)
        {
            ElAnimator.SetBool("Open", false);
            StartCoroutine(WaitSoundFXEnd());
            
        }
    }
    IEnumerator WaitSoundFXEnd()
    {
        
        SoundFX.Play();
        yield return new WaitWhile(() => SoundFX.isPlaying);
        SceneLoadManager.Instance.SwitchSceneinLoading();

    }
}
