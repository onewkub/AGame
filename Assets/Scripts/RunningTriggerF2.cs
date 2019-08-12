using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningTriggerF2 : MonoBehaviour
{
    public GameObject MadnessNurse;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ghost")
        {
            SceneEventSecondFloor.Instance.openAllLight();
        }
        MadnessNurse.GetComponent<NurseMadnessSecondFloor>().running = true;
        ElevatorController.Instance.closeElevator();
    }
}
