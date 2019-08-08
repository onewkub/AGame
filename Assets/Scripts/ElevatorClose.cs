using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorClose : MonoBehaviour
{
    public GameObject ElDoor;
    public GameObject Nurse;
    public GameObject Player;
    public GameObject Head;
    public GameObject Cam;
    public bool NurseNotArrive = true;

    private Animator ElAnimator;
    private AudioSource SoundFX;
    private Transform lastPosOfPlayer;
    private NurseWalkingF1Script nurseWalkingScript;


    private void Awake()
    {
        ElAnimator = ElDoor.GetComponent<Animator>();
        SoundFX = ElDoor.GetComponent<AudioSource>();
        nurseWalkingScript = Nurse.GetComponent<NurseWalkingF1Script>();
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
        GameManager.gameManager.PlayerPos = Player.transform.position;
        GameManager.gameManager.PlayerRot = Player.transform.rotation;
        GameManager.gameManager.headRot = Head.transform.rotation;
        GameManager.gameManager.camRot = Cam.transform.rotation;
        GameManager.gameManager.NursePos = Nurse.transform.position;
        GameManager.gameManager.NurseRot = Nurse.transform.rotation;
        //Debug.Log("Saving Position: " + GameManager.gameManager.PlayerPos);

        SceneLoadManager.Instance.SwitchSceneinLoading();

    }
}
