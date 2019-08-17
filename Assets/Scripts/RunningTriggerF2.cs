using UnityEngine;

public class RunningTriggerF2 : MonoBehaviour
{
    public GameObject MadnessNurse;
    private SoundFXController sfxController;
    private void Awake()
    {
        sfxController = MadnessNurse.GetComponent<SoundFXController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ghost2")
        {
            SceneEventSecondFloor.Instance.openAllLight();
        }
        MadnessNurse.GetComponent<NurseMadnessSecondFloor>().running = true;
        sfxController.ScreamSound();
        ElevatorController.Instance.closeElevator();
    }
}
