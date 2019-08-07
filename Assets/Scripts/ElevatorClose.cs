using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorClose : MonoBehaviour
{
    public GameObject ElDoor;
    public GameObject Nurse;
    public bool NurseNotArrive = true;
    private Animator ElAnimator;
    private AudioSource SoundFX;
    private Transform lastPosOfPlayer;
    private NurseWalkingScript nurseWalkingScript;

    private void Awake()
    {
        ElAnimator = ElDoor.GetComponent<Animator>();
        SoundFX = ElDoor.GetComponent<AudioSource>();
        nurseWalkingScript = Nurse.GetComponent<NurseWalkingScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(createEvent());
        }
    }
    IEnumerator createEvent()
    {
        nurseWalkingScript.PlayerNotArrive = false;
        yield return new WaitWhile(() => NurseNotArrive);

        ElAnimator.SetBool("Open", false);
        SoundFX.Play();
        yield return new WaitWhile(() => SoundFX.isPlaying);
        SceneLoadManager.Instance.SwitchSceneinLoading();

    }
}
