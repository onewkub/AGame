using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInsideF1Bloody : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ElevatorController.Instance.openElevator();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ElevatorController.Instance.closeElevator();
            gameObject.SetActive(false);
        }
    }
}
