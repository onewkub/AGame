using System.Collections;
using UnityEngine;

public class ElevatorClose : MonoBehaviour
{
    public GameObject Nurse;
    public GameObject Player;
    public GameObject Head;
    public GameObject Cam;
    public bool NurseNotArrive = true;

    private Transform lastPosOfPlayer;
    private NurseWalkingF1Script nurseWalkingScript;



    private void Awake()
    {
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
        ElevatorController.Instance.closeElevator();
        yield return new WaitWhile(() => ElevatorController.Instance.SoundFXisPlaying());
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
